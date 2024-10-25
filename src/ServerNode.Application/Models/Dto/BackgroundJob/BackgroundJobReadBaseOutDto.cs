using Google.Protobuf.WellKnownTypes;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.BackgroundJob;

public class BackgroundJobReadBaseOutDto : IEntityBaseOutDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}