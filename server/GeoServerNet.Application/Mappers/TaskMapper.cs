using GeoServerNet.Application.CQRS.Tasks.Commands;
using Task = GeoServerNet.Server.DAL.Entities.Task;

namespace GeoServerNet.Application.Mappers;

public static class TaskMapper
{
    public static Task ToTask(int taskId) =>
        new()
        {
            Id = taskId,
            StartedAt = default,
            EndedAt = default,
            TaskStatus = TaskStatus.Created,
            ExitCode = 0,
        };

}