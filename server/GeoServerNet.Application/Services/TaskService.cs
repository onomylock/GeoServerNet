using GeoServerNet.Application.CQRS.Tasks.Commands;
using GeoServerNet.Application.Mappers;
using GeoServerNet.Common.Data.Dto;
using GeoServerNet.Server.DAL.Entities;
using GeoServerNet.Server.DAL.Services;
using Microsoft.Extensions.Logging;
using Task = System.Threading.Tasks.Task;

namespace GeoServerNet.Application.Services;

public interface ITaskService
{
    public Task DeleteDirectory(CancellationToken cancellationToken = default);
    public Task ClearDirectory(CancellationToken cancellationToken = default);
    public Task AddNewTask(int taskId, IEnumerable<DependencyDto> collection, CancellationToken cancellationToken = default);
    public Task<GeoServerNet.Server.DAL.Entities.Task> GetTaskById(int id, CancellationToken cancellationToken = default);
    public Task<IReadOnlyCollection<Server.DAL.Entities.Task>> GetCollection(
        CancellationToken cancellationToken = default);
    public Task RunTask(int id, CancellationToken cancellationToken = default);
}

public sealed class TaskService(ITaskEntityService taskEntityService, ILogger<TaskService> logger)
    : ITaskService
{
    public Task DeleteDirectory(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task ClearDirectory(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddNewTask(int taskId, IEnumerable<DependencyDto> collection, CancellationToken cancellationToken = default)
    {
        var task = TaskMapper.ToTask(taskId);
        var dependencyCollection = collection.Select(x => DependencyMapper.ToDependency(x, taskId)); 
        task.Dependencies = dependencyCollection.ToList();
        await taskEntityService.AddTask(task, cancellationToken);
    }

    public Task<Server.DAL.Entities.Task> GetTaskById(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Server.DAL.Entities.Task>> GetCollection(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RunTask(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}