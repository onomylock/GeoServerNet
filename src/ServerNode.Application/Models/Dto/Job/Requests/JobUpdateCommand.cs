using MediatR;
using Shared.Common.Models.Dto;
using Shared.Domain.View;

namespace ServerNode.Application.Models.Dto.Job.Requests;

public class JobUpdateCommand : JobTargetDtoBase, IRequest<OkOutDto>
{
    public KeyValueEntry Metadata { get; set; }
    public string Uri { get; set; }    
}