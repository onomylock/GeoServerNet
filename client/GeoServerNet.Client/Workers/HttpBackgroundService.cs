using GeoServerNet.Client.Abstraction;
using GeoServerNet.Client.Abstraction.BackgroundServices;

namespace GeoServerNet.Client.Workers;

public class HttpBackgroundService: IScopedBackgroundService
{
    public Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}