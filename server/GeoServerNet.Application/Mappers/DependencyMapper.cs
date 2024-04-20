using GeoServerNet.Common.Data.Dto;
using GeoServerNet.Server.DAL.Entities;

namespace GeoServerNet.Application.Mappers;

public static class DependencyMapper
{
    public static Dependency ToDependency(DependencyDto dto, int taskId) =>
        new()
        {
            ServerName = dto.ServerName,
            ClientName = dto.ClientName,
            DependencyType = dto.DependencyType,
            TaskId = taskId
        };
}