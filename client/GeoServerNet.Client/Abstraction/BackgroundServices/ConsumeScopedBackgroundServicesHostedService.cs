namespace GeoServerNet.Client.Abstraction.BackgroundServices;

public sealed class ConsumeScopedBackgroundServicesHostedService(IServiceProvider serviceProvider): BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceProvider.CreateScope();
        
        scope.ServiceProvider.GetServices<IScopedBackgroundService>();
        return Task.CompletedTask;
    }
}