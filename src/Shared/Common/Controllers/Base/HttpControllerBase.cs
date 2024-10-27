using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Application.Services;
using Shared.Common.Models;
using Shared.Common.Models.DTO.Base;
using Shared.Common.Models.Dto.Generic;

namespace Shared.Common.Controllers.Base;

[ProducesResponseType(typeof(ErrorModelResult), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(ErrorModelResult), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(ErrorModelResult), StatusCodes.Status403Forbidden)]
[ProducesResponseType(typeof(ErrorModelResult), StatusCodes.Status500InternalServerError)]
public class HttpControllerBase(
    IHttpContextAccessor httpContextAccessor,
    IWarningService warningService,
#pragma warning disable CS9113 // Parameter is unread.
    ILogger<HttpControllerBase> logger)
#pragma warning restore CS9113 // Parameter is unread.
    : ControllerBase
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    protected IActionResult ResponseWith(IOutDtoBase response)
    {
        
        var warnings = warningService.GetEntries();

        response.Warnings = warnings.Count != 0 ? warnings : null;

        switch (response)
        {
            case FileOutDto fileResult:
            {
                var file = File(fileResult.Stream, fileResult.ContentType, fileResult.FileName);
                file.EnableRangeProcessing = true;
                return file;
            }
            default:
                return new OkObjectResult(response);
        }
    }
}