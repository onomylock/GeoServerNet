using MediatR;
using ServerNode.Application.Models.Dto.BackgroundJob;
using ServerNode.Application.Models.Dto.BackgroundJob.Requests;

namespace ServerNode.Infrastructure.Handlers.Queries.BackgroundJob;

public class BackgroundJobReadCollectionSearchQueryHandler : IRequestHandler<BackgroundJobReadCollectionSearchQuery, BackgroundJobReadCollectionOutDto>
{
    public Task<BackgroundJobReadCollectionOutDto> Handle(BackgroundJobReadCollectionSearchQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}