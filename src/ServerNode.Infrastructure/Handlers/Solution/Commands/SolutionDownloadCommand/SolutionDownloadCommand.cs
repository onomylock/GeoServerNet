using System.ComponentModel.DataAnnotations;
using MediatR;
using ServerNode.Application.Models.Dto.Solution;
using Shared.Common.Models.DTO.Base;
using Shared.Domain.View;

namespace ServerNode.Infrastructure.Handlers.Solution.Commands.SolutionDownloadCommand;

public class SolutionDownloadCommand : SolutionTargetDtoBase, IRequest<ResponseBase<SolutionReadDto>> 
{
    [Required] public string Path { get; set; }
    [Required] public string BucketName { get; set; }
    public List<KeyValueEntry> Metadata { get; set; } = new();
}