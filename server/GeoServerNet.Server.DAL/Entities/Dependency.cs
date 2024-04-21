using GeoServerNet.Common.Enums;
using GeoServerNet.Server.DAL.Entities.Base;

namespace GeoServerNet.Server.DAL.Entities;

public record Dependency : EntityBase
{
    public required string ServerName { get; set; }
    public required string ClientName { get; set; }
    public required DependencyType DependencyType { get; set; }
    public int TaskId { get; set; }
}