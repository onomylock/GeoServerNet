using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServerNode.Application.Models.Dto;
using Shared.Common.Models.DTO.Base;


namespace ServerNode.Application.UseCases.Job.Queries.JobReadCollectionQuery;

public class JobReadCollectionSearchQuery :
    IRequest<PaginationResponseBase<IReadOnlyCollection<JobDto>>>
{
    [MinLength(1)] [MaxLength(64)] public string Term { get; set; }
    [Required] public PageModel PageModel { get; set; }
}