using MediatR;
using ServerNode.Application.Models.Dto.Job;
using ServerNode.Application.Models.Dto.Job.Requests;

namespace ServerNode.Infrastructure.Handlers.Queries.Job;

public class JobReadCollectionSearchQueryHandler : IRequestHandler<JobReadCollectionSearchQuery, JobReadCollectionOutDto>
{
    public Task<JobReadCollectionOutDto> Handle(JobReadCollectionSearchQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}