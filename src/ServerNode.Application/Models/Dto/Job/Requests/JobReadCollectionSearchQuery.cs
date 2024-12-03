using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.Job.Requests;

public class JobReadCollectionSearchQuery :
    IEntityCollectionPageModelInDto,
    IRequest<JobReadCollectionOutDto>,
    IInDto
{
    [MinLength(1)] [MaxLength(64)] public string Term { get; set; }
    [Required] public PageModel PageModel { get; set; }
}