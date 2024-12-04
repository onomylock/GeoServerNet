using System.ComponentModel.DataAnnotations;

namespace ServerNode.Application.Models.Dto;

public class JobDto
{
    [Required] public string JobId { get; set; }
}