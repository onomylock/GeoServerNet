using MediatR;
using ServerNode.Application.Models.Dto.Job.Requests;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Commands.Job;

public class JobDeleteCommandHandler : IRequestHandler<JobDeleteCommand, IOutDtoBase>
{
    public Task<IOutDtoBase> Handle(JobDeleteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}