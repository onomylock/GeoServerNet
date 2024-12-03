using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerNode.Application.Models.Dto.Job;
using ServerNode.Application.Models.Dto.Job.Requests;
using Shared.Application.Services;
using Shared.Common.Controllers.Base;

namespace ServerNode.HttpApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class JobController(
    IMediator mediator,
    IHttpContextAccessor httpContextAccessor,
    IWarningService warningService,
    ILogger<HttpControllerBase> logger
) : HttpControllerBase(httpContextAccessor, warningService, logger)
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] JobCreateCommand command,
        CancellationToken cancellationToken = default)
    {
        return ResponseWith(await mediator.Send(command, cancellationToken));
    }
    
    
    
}