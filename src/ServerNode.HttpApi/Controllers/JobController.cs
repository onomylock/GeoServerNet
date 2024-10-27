using Microsoft.AspNetCore.Mvc;
using Shared.Application.Services;
using Shared.Common.Controllers.Base;

namespace ServerNode.HttpApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class JobController(
    IHttpContextAccessor httpContextAccessor,
    IWarningService warningService,
    ILogger<HttpControllerBase> logger) : HttpControllerBase(httpContextAccessor, warningService, logger)
{
}