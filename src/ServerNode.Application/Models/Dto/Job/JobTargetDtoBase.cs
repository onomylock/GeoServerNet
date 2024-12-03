using System.ComponentModel.DataAnnotations;

namespace ServerNode.Application.Models.Dto.Job;

public class JobTargetDtoBase
{
    [Required] public string JobId { get; set; }
}