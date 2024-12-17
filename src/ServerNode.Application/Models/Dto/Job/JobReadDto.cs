using System.ComponentModel.DataAnnotations;

namespace ServerNode.Application.Models.Dto.Job;

public class JobReadDto
{
    [Required] public string JobId { get; set; }
}