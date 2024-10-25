namespace Shared.Common.Models.DTO.Base;

public interface IEntityBaseOutDto
{
    Guid Id { get; set; }

    DateTimeOffset CreatedAt { get; set; }

    DateTimeOffset UpdatedAt { get; set; }
}