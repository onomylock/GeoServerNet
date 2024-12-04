using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Shared.Common.Exceptions;
using Shared.Common.Models.DTO.Base;

namespace Shared.Common.Middlewares;

public class ValidationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (CustomValidationException ex)
        {
            context.Response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(context.Response.Body, new ResponseBase<object> { Message = "Validation Errors", Errors = ex.Errors });
        }
    }
}