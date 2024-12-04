using MediatR;
using ServerNode.Application.Models.Dto;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.UseCases.Job.Queries.JobReadCollectionQuery;

public class JobReadCollectionSearchHandler : IRequestHandler<JobReadCollectionSearchQuery, PaginationResponseBase<IReadOnlyCollection<JobDto>>>
{
    public Task<PaginationResponseBase<IReadOnlyCollection<JobDto>>> Handle(JobReadCollectionSearchQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}