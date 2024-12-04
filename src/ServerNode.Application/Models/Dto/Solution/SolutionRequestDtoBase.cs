using System.ComponentModel.DataAnnotations;

namespace ServerNode.Application.Models.Dto.Solution;

public class SolutionRequestDtoBase
{
    [Required] public Guid Id { get; set; }
}