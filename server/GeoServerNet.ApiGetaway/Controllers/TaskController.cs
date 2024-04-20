using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeoServerNet.ApiGetaway.Controllers;

[ApiController]
[Route("")]
public class TaskController(IMediator mediator) : ControllerBase
{
    [HttpPost("add_task")]
    public async Task<IActionResult> AddTask([FromBody] AddTaskCommand command,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(command, cancellationToken));
    
    [HttpPost("stop_task")]
    public async Task<IActionResult> StopTask([FromBody] StopTaskCommand command,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(command, cancellationToken));

    [HttpGet("running_tasks_count")]
    public async Task<IActionResult> RunningTaskCount([FromQuery] RunningTaskCountQuery query,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(query, cancellationToken));

    [HttpGet("list_tasks")]
    public async Task<IActionResult> ListTasks([FromQuery] ListTasksQuery query,
        CancellationToken cancellationToken = default) => Ok(await mediator.Send(query, cancellationToken));
    
    
}