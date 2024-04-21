using GeoServerNet.Client.Abstraction.BackgroundServices;
using GeoServerNet.Client.Options;
using GeoServerNet.Client.Services;
using GeoServerNet.Common.Services;

namespace GeoServerNet.Client.Workers;

public class HttpBackgroundService: ScopedBackgroundService
{
    private UpdateDelayOptions _updateDelayOptions;
    private readonly IHttpApiClientService _clientService;
    private readonly ILogger<HttpBackgroundService> _logger;

    public HttpBackgroundService(
        IWritableOptionsService<UpdateDelayOptions> writableOptionsService,
        IHttpApiClientService clientService, 
        ILogger<HttpBackgroundService> logger, 
        IHostApplicationLifetime hostApplicationLifetime) : base(logger, hostApplicationLifetime)
    {
        _clientService = clientService;
        _logger = logger;
        writableOptionsService.Change += WritableOptionsServiceOnChange;
        WritableOptionsServiceOnChange(writableOptionsService.CurrentValue);
    }

    protected override async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(_updateDelayOptions.UpdateHttpClientDelaySeconds));

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _clientService.UpdateAsync(stoppingToken);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "update tasks failed!");
                }

                await periodicTimer.WaitForNextTickAsync(stoppingToken);
            }
        }
        catch (OperationCanceledException)
        {
            //ignore
        }
    }
    
    private void WritableOptionsServiceOnChange(UpdateDelayOptions options, string s = null)
    {
        _updateDelayOptions = options;
        OnInitOrChange(options.UpdateHttpClientDelaySeconds > 0);
    }
}