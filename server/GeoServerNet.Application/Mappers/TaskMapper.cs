using Task = GeoServerNet.Server.DAL.Entities.Task;

namespace GeoServerNet.Application.Mappers;

public static class TaskMapper
{
    public static Task ToTask(int taskId, string? arguments) =>
        new()
        {
            Id = taskId,
            StartedAt = default,
            EndedAt = default,
            TaskStatus = TaskStatus.Created,
            ExitCode = 0,
            Arguments = arguments
        };

}