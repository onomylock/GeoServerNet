using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerNode.Application.Services.Data;
using ServerNode.Infrastructure.Helpers;
using Shared.Application.Data;
using Shared.Application.Services;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Solution.Commands.SolutionDeleteCommand;

public class SolutionDeleteHandler(
    IValidator<SolutionDeleteCommand> validator,
    IFileService fileService,
    IDbContextTransactionAction dbContextTransactionAction,
    ISolutionEntityService solutionEntityService
) : IRequestHandler<SolutionDeleteCommand, ResponseBase<OkResult>>
{
    public async Task<ResponseBase<OkResult>> Handle(SolutionDeleteCommand request, CancellationToken cancellationToken)
    { 
        var response = new ResponseBase<OkResult>();
        try
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var solutionTarget = await solutionEntityService.GetByIdAsync(request.Id, true, cancellationToken);
            
            await fileService.DeleteFolderAsync(Path.Combine(FileHelper.BuildsPath, solutionTarget.Path), cancellationToken);
            
            await dbContextTransactionAction.BeginTransactionAsync(cancellationToken);
                        
            await solutionEntityService.DeleteAsync(solutionTarget, cancellationToken);
            
            await dbContextTransactionAction.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            
            await dbContextTransactionAction.RollbackTransactionAsync(CancellationToken.None);
        }

        response.Data = new OkResult();
        return response;
    }
}