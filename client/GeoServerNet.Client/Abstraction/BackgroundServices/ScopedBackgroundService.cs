namespace GeoServerNet.Client.Abstraction.BackgroundServices;

public abstract class ScopedBackgroundService(ILogger<ScopedBackgroundService> logger,
 IHostApplicationLifetime hostApplicationLifetime)
 : BackgroundService
{ 
    private TaskCompletionSource TaskCompletionSource { get; set; }
    private bool IsActive { get; set; }
    private CancellationTokenSource CancellationTokenSource { get; set; }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    { 
        if (IsActive)
            try
            {
                CancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
                
                await Task.Factory.StartNew(() => DoWorkAsync(CancellationTokenSource.Token), TaskCreationOptions.LongRunning);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        
        TaskCompletionSource?.TrySetResult();
    }
    
    protected abstract Task DoWorkAsync(CancellationToken stoppingToken);
    
    protected void OnInitOrChange(bool isActive, bool isInit = false)
    {
        IsActive = isActive;
        
        CancellationTokenSource?.Cancel();
        CancellationTokenSource?.Dispose();
        CancellationTokenSource = null;
        
        TaskCompletionSource?.Task.Wait();
        
        if (!isActive) return;
        
        TaskCompletionSource = new TaskCompletionSource();
        
        Task.Factory.StartNew(() => ExecuteAsync(hostApplicationLifetime.ApplicationStopping), TaskCreationOptions.LongRunning);
    }
}