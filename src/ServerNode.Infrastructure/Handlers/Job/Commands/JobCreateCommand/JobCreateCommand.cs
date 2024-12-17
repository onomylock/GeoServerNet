using MediatR;
using ServerNode.Application.Models.Dto.Job;
using Shared.Common.Models.DTO.Base;
using Shared.Domain.View;

namespace ServerNode.Infrastructure.Handlers.Job.Commands.JobCreateCommand;

public class JobCreateCommand : IRequest<ResponseBase<JobReadDto>>
{
    public Guid SolutionId { get; set; }
    public List<KeyValueEntry> Metadata { get; set; }
}