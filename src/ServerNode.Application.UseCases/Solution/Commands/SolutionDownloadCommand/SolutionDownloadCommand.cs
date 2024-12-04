using System.ComponentModel.DataAnnotations;
using MediatR;
using ServerNode.Application.Models.Dto;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.UseCases.Solution.Commands.SolutionDownloadCommand;

public class SolutionDownloadCommand : IRequest<ResponseBase<SolutionDto>>
{
    [Required] public Guid SolutionId { get; set; }
    [Required] public Uri Uri { get; set; }
}