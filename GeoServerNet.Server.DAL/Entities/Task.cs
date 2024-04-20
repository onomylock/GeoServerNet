using GeoServerNet.Server.DAL.Entities.Base;

namespace GeoServerNet.Server.DAL.Entities;

public record Task : EntityBase
{
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset EndedAt { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public int ExitCode { get; set; }
    public ICollection<Dependency> Dependencies { get; set; } = new List<Dependency>();
}