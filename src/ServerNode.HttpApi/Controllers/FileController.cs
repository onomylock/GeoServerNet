using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerNode.Application.Models.Dto.File.Requests;
using Shared.Application.Services;
using Shared.Common.Controllers.Base;

namespace ServerNode.HttpApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FileController(
    IMediator mediator,
    IHttpContextAccessor httpContextAccessor,
    IWarningService warningService,
    ILogger<HttpControllerBase> logger
) : HttpControllerBase(httpContextAccessor, warningService, logger)
{
    [HttpPost]
    public async Task<IActionResult> Download(
        [FromBody] FileDownloadCommand command,
        CancellationToken cancellationToken = default)
    {
        return ResponseWith(await mediator.Send(command, cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> Upload(
        [FromQuery] FileUploadCommand command,
        CancellationToken cancellationToken = default)
    {
        return ResponseWith(await mediator.Send(command, cancellationToken));
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(
        [FromQuery] FileDeleteCommand command,
        CancellationToken cancellationToken = default)
    {
        return ResponseWith(await mediator.Send(command, cancellationToken));
    }
    
    [HttpGet]
    public async Task<IActionResult> Read(
        [FromQuery] FileReadQuery query,
        CancellationToken cancellationToken = default)
    {
        return ResponseWith(await mediator.Send(query, cancellationToken));
    }
    
    [HttpGet]
    public async Task<IActionResult> ReadCollection(
        [FromQuery] FileReadCollectionSearchQuery query,
        CancellationToken cancellationToken = default)
    {
        return ResponseWith(await mediator.Send(query, cancellationToken));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(
        [FromBody] FileUpdateCommand command,
        CancellationToken cancellationToken = default)
    {
        return ResponseWith(await mediator.Send(command, cancellationToken));
    }
    
}