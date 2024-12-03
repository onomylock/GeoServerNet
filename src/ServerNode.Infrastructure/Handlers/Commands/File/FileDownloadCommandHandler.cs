using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ServerNode.Application.Models.Dto.File.Requests;
using Shared.Application.Services;
using Shared.Common.Models.Dto;

namespace ServerNode.Infrastructure.Handlers.Commands.File;

public class FileDownloadCommandHandler(
    IFileService fileService,
    IValidator<FileDownloadCommand> validator,
    HttpClient httpClient,
    Logger<FileDownloadCommandHandler> logger
    ) : IRequestHandler<FileDownloadCommand, OkOutDto>
{
    public async Task<OkOutDto> Handle(FileDownloadCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            await using var stream = await httpClient.GetStreamAsync(request.Uri, cancellationToken);
        
            await fileService.ExtractArchiveAsync(stream, request.Path, cancellationToken);

            return new OkOutDto();
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);            
            throw;
        }
    }
}