using GeoServerNet.Application.CQRS.Files.Commands;
using GeoServerNet.Application.CQRS.Files.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeoServerNet.ApiGetaway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController(IMediator mediator) : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromBody] UploadCommand command,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(command, cancellationToken));

    [HttpGet("download")]
    public async Task<IActionResult> Download([FromQuery] DownloadQuery query,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(query, cancellationToken));

    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] FileListQuery query,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(query, cancellationToken));

    [HttpPost("archive")]
    public async Task<IActionResult> Archive([FromBody] ArchiveCommand command,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(command, cancellationToken));

    [HttpDelete("delete_file")]
    public async Task<IActionResult> DeleteFile([FromBody] DeleteFileCommand command,
        CancellationToken cancellationToken = default) =>
        Ok(await mediator.Send(command, cancellationToken));

    [HttpGet("file_content")]
    public async Task<IActionResult> FileContent([FromQuery] FileContentQuery query,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(query, cancellationToken));

    [HttpPost("clear_folder")]
    public async Task<IActionResult> ClearFolder([FromBody] ClearFolderCommand command,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(command, cancellationToken));
}