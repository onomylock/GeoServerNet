using System.Reflection;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GeoServerNet.Application.Logging;

public class LoggingBehaviour<TRequest, TResponse>(
    ILogger<LoggingBehaviour<TRequest, TResponse>> logger
    ) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Request
        logger.LogInformation("Handling {Name}", typeof(TRequest).Name);
        var myType = request.GetType();
        var props = new List<PropertyInfo>(myType.GetProperties());
        foreach (var prop in props)
        {
            var propValue = prop.GetValue(request, null);
            logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
        }
        var response = await next();
        //Response
        logger.LogInformation("Handled {Name}", typeof(TResponse).Name);
        return response;
    }
}