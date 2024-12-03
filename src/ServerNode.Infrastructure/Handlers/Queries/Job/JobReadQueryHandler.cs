using MediatR;
using ServerNode.Application.Models.Dto.Job;
using ServerNode.Application.Models.Dto.Job.Requests;

namespace ServerNode.Infrastructure.Handlers.Queries.Job;

public class JobReadQueryHandler : IRequestHandler<JobReadQuery, JobReadOutDto>
{
    public Task<JobReadOutDto> Handle(JobReadQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}