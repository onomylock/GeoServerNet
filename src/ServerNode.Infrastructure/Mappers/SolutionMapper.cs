using ServerNode.Application.Models.Dto.Solution;
using ServerNode.Domain.Entities;

namespace ServerNode.Infrastructure.Mappers;

public static class SolutionMapper
{
    public static SolutionReadDto ToSolutionReadDto(Solution targetSolution)
    {
        return new SolutionReadDto
        {
            Id = targetSolution.Id,
            Name = targetSolution.Name,
            CreatedAt = targetSolution.CreatedAt,
            UpdatedAt = targetSolution.UpdatedAt
        };
    }
}