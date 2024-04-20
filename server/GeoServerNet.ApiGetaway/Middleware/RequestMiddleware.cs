using Prometheus;

namespace GeoServerNet.ApiGetaway.Middleware;

public class RequestMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
{
    public async Task Invoke(HttpContext httpContext)  
    {  
        var path = httpContext.Request.Path.Value;  
        var method = httpContext.Request.Method;  
  
        var counter = Metrics.CreateCounter("prometheus_demo_request_total", "HTTP Requests Total", new CounterConfiguration  
        {  
            LabelNames = new[] { "path", "method", "status" }  
        });  
  
        var statusCode = 200;  
  
        try  
        {  
            await next.Invoke(httpContext);  
        }  
        catch (Exception)  
        {  
            statusCode = 500;  
            counter.Labels(path, method, statusCode.ToString()).Inc();  
  
            throw;  
        }  
          
        if (path != "/metrics")  
        {  
            statusCode = httpContext.Response.StatusCode;  
            counter.Labels(path, method, statusCode.ToString()).Inc();  
        }  
    }  
}  
  
public static class RequestMiddlewareExtensions  
{          
    public static IApplicationBuilder UseRequestMiddleware(this IApplicationBuilder builder)  
    {  
        return builder.UseMiddleware<RequestMiddleware>();  
    }  
}     
