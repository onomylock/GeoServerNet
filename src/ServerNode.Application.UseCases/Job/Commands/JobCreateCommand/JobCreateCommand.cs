using MediatR;
using ServerNode.Application.Models.Dto;
using Shared.Common.Models.DTO.Base;
using Shared.Domain.View;

namespace ServerNode.Application.UseCases.Job.Commands.JobCreateCommand;

public class JobCreateCommand : IRequest<ResponseBase<JobDto>>
{
    public List<KeyValueEntry> Metadata { get; set; }
}