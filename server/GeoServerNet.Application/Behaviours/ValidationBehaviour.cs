using FluentValidation;
using FluentValidation.Results;
using GeoServerNet.Application.Exeptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GeoServerNet.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators,
    ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any()) return await next();
        
        var typeName = request.GetType().Name;
 
        logger.LogInformation("----- Validating command {CommandType}", typeName);
 
 
        var context = new ValidationContext<TRequest>(request);
        var validationResults =
            await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(result => result.Errors)
            .Where(error => error != null).ToList();
            
        if (!failures.Any()) return await next();
            
        logger.LogWarning(
            "Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}",
            typeName, request, failures);
 
        throw new CqrsDomainException(
            $"Command Validation Errors for type {typeof(TRequest).Name}",
            new ValidationException("Validation exception", failures));
    }
}

