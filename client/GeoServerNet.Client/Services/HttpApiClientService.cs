namespace GeoServerNet.Client.Services;

public interface IHttpApiClientService
{
    Task UpdateAsync(CancellationToken cancellationToken = default);
    
}

public class HttpApiClientService : IHttpApiClientService
{
    private readonly ILogger<HttpApiClientService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    
    public HttpApiClientService(
        ILogger<HttpApiClientService> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }
    
    


    public Task UpdateAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}