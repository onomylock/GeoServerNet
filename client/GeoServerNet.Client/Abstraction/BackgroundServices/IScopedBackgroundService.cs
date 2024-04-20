namespace GeoServerNet.Client.Abstraction.BackgroundServices;

public interface IScopedBackgroundService
{
    Task ExecuteAsync(CancellationToken stoppingToken);
}