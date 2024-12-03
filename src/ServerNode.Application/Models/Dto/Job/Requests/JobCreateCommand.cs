using MediatR;
using Shared.Common.Models.DTO.Base;
using Shared.Domain.View;

namespace ServerNode.Application.Models.Dto.Job.Requests;

public class JobCreateCommand : IRequest<JobReadOutDto>, IInDto
{
    public List<KeyValueEntry> Metadata { get; set; }
    public string Uri { get; set; }
}