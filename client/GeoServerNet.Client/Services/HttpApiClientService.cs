using GeoServerNet.Client.Options;
using GeoServerNet.Common.Services;

namespace GeoServerNet.Client.Services;

public interface IHttpApiClientService
{
    Task UpdateAsync(CancellationToken cancellationToken = default);
}

public class HttpApiClientService : IHttpApiClientService
{
    private readonly ILogger<HttpApiClientService> _logger;
    
    
    public HttpApiClientService(
        ILogger<HttpApiClientService> logger)
    {
        
        _logger = logger;
    }
    
    


    public Task UpdateAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}