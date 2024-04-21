using GeoServerNet.Client.Models;
using GeoServerNet.Client.Options;
using GeoServerNet.Common.Services;

namespace GeoServerNet.Client.Services;

public interface ITaskClientService
{
        
}

public class TaskClientService : ITaskClientService
{
    private readonly IWritableOptionsService<StartUpOptions> _writableOptionsService;
    private readonly IHttpClientFactory _httpClientFactory;
    private StartUpOptions _startUpOptions; 
    

    public TaskClientService(IWritableOptionsService<StartUpOptions> writableTaskOptionsService,
        IHttpClientFactory httpClientFactory)
    {
        _writableOptionsService = writableTaskOptionsService;
        _httpClientFactory = httpClientFactory;
        _writableOptionsService.Change += WritableOptionsServiceOnChange;
    }

    private void WritableOptionsServiceOnChange(StartUpOptions options, string s = null)
    {
        _startUpOptions = options;
        
        
    }
}