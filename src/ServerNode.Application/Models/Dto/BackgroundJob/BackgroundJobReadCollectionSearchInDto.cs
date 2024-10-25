using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.BackgroundJob;

public class BackgroundJobReadCollectionSearchInDto : IEntityCollectionPageModelInDto, IInDto
{
    [MinLength(1)] [MaxLength(64)] public string Term { get; set; }
    [Required] public PageModel PageModel { get; set; }
}