using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Options;

public class DbContextOptions
{
    [Required] [MinLength(1)] public string ConnectionString { get; set; }
}