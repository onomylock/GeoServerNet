using FluentValidation;
using MediatR;
using ServerNode.Application.Models.Dto.Solution;
using ServerNode.Application.Services.Data;
using ServerNode.Infrastructure.Helpers;
using ServerNode.Infrastructure.Mappers;
using Shared.Application.Data;
using Shared.Application.Services;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Solution.Commands.SolutionDownloadCommand;

public class SolutionDownloadHandler(
    IValidator<SolutionDownloadCommand> validator,
    IFileService fileService, 
    HttpClient httpClient,
    IDbContextTransactionAction dbContextTransactionAction,
    IMinioService minioService,
    ISolutionEntityService solutionEntityService
) : IRequestHandler<SolutionDownloadCommand, ResponseBase<SolutionReadDto>>
{
    public async Task<ResponseBase<SolutionReadDto>> Handle(SolutionDownloadCommand request, CancellationToken cancellationToken)
    {
        var response = new ResponseBase<SolutionReadDto>();
        try
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var uri = await minioService.GetFileUrl(request.Path, request.BucketName, cancellationToken);
            
            var requestStream = await httpClient.GetStreamAsync(uri, cancellationToken);

            var solutionPath = await fileService.ExtractArchiveAsync(requestStream, FileHelper.BuildsPath, cancellationToken);

            await dbContextTransactionAction.BeginTransactionAsync(cancellationToken);

            var targetSolution = new Domain.Entities.Solution
            {
                CreatedAt = DateTimeOffset.UtcNow,
                MasterId = request.Id,
                Metadata = request.Metadata,
                Path = solutionPath
            };
            
            await solutionEntityService.SaveAsync(targetSolution, cancellationToken);
            
            await dbContextTransactionAction.CommitTransactionAsync(cancellationToken);
            
            response.Data = SolutionMapper.ToSolutionReadDto(targetSolution);
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            
            await dbContextTransactionAction.RollbackTransactionAsync(CancellationToken.None);
        }

        return response;
    }
}