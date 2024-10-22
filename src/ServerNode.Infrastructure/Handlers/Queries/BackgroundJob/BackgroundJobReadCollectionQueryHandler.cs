using MediatR;
using ServerNode.Application.Models.Dto.BackgroundJob;
using Shared.Common.Models.Dto;

namespace ServerNode.Infrastructure.Handlers.Queries.BackgroundJob;

public class BackgroundJobReadCollectionQueryHandler : IRequestHandler<BackgroundJobReadCollectionQuery, PageModelResult<BackgroundJobReadResponse>>
{
    public Task<PageModelResult<BackgroundJobReadResponse>> Handle(BackgroundJobReadCollectionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}