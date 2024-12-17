using MediatR;
using ServerNode.Application.Models.Dto.Job;
using Shared.Application.Services;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Job.Commands.JobCreateCommand;

public class JobCreateHandler(
    IJobService jobService
) : IRequestHandler<JobCreateCommand, ResponseBase<JobReadDto>>
{
    public Task<ResponseBase<JobReadDto>> Handle(JobCreateCommand request, CancellationToken cancellationToken)
    {
        
    }
}