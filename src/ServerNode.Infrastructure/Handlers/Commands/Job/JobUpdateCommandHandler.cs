using MediatR;
using ServerNode.Application.Models.Dto.Job.Requests;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Commands.Job;

public class JobUpdateCommandHandler : IRequestHandler<JobUpdateCommand, IOutDtoBase>
{
    public Task<IOutDtoBase> Handle(JobUpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}