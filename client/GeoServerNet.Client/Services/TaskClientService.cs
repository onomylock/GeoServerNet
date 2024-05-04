using System.Collections.Concurrent;
using GeoServerNet.Client.Algorithms;
using GeoServerNet.Client.Models;
using GeoServerNet.Client.Options;

namespace GeoServerNet.Client.Services;

public interface ITaskClientService
{
    Task AddTaskAsync(TaskEntityDto task, CancellationToken cancellationToken = default);
    Task DeleteTaskAsync(int id, CancellationToken cancellationToken = default);
    Task StartTaskAsync(int id, CancellationToken cancellationToken = default);
    Task InvokeTaskState(CancellationToken cancellationToken = default);
    Task DownloadTaskAsync(CancellationToken cancellationToken = default);
    Task StopTaskAsync(int id, CancellationToken cancellationToken = default);
}

public class TaskClientService : ITaskClientService
{
    private StartUpOptions? _startUpOptions;
    private ConcurrentDictionary<int, ITaskAlgorithm>? _taskAlgorithms;

    public TaskClientService(
        IConfiguration configuration)
    {
        _startUpOptions = configuration.GetSection(StartUpOptions.StartUp).Get<StartUpOptions>();
        
    }

    public Task AddTaskAsync(TaskEntityDto task, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTaskAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task StartTaskAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task InvokeTaskState(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DownloadTaskAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task StopTaskAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}