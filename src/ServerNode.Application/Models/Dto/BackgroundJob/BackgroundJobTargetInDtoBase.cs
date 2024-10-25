using System.ComponentModel.DataAnnotations;

namespace ServerNode.Application.Models.Dto.BackgroundJob;

public class BackgroundJobTargetInDtoBase
{
    [Required] public int BackgroundJobId { get; set; }
}