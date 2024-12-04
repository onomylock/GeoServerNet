using Shared.Domain.Entity;
using Shared.Domain.View;

namespace ServerNode.Domain.Entities;

public record Solution : EntityBase
{
    public Guid MasterId { get; set; }
    public List<KeyValueEntry> Metadata { get; set; } = new();
}