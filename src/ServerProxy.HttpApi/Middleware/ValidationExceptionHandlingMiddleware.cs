

using FluentValidation;
using Shared.Enums;
using Shared.Models;

namespace ServerProxy.HttpApi.Middleware;

public sealed class ValidationExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException exception)
        {
            var errors = exception.Errors
                .Select(x => new ErrorModelResultEntry(ErrorType.ModelState, x.ErrorMessage))
                .ToList();

            var errorModelResult = new ErrorModelResult
            {
                Errors = errors
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(errorModelResult);
        }
    }
}

public static class ValidationExceptionHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseValidationExceptionHandlingMiddleware(this IApplicationBuilder builder)  
    {  
        return builder.UseMiddleware<ValidationExceptionHandlingMiddleware>();  
    }  
}