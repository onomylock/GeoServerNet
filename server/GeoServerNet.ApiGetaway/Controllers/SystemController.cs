using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeoServerNet.ApiGetaway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SystemController(IMediator mediator) : ControllerBase
{
    [HttpPost("shutdown")]
    public async Task<IActionResult> Shutdown([FromBody] ShutdownCommand command,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(command, cancellationToken));

    [HttpGet("echo")]
    public async Task<IActionResult> Echo([FromQuery] EchoQuery query, CancellationToken cancellationToken = default) =>
        Ok(await mediator.Send(query, cancellationToken));

    [HttpGet("status")]
    public async Task<IActionResult> Status([FromQuery] StatusQuery query,
        CancellationToken cancellationToken = default) =>
        Ok(await mediator.Send(query, cancellationToken));
    
    [HttpGet("version")]
    public async Task<IActionResult> Version([FromQuery] VersionQuery query,
        CancellationToken cancellationToken = default) =>
        Ok(await mediator.Send(query, cancellationToken));
}