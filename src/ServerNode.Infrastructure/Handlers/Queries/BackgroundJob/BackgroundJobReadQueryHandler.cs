using MediatR;
using ServerNode.Application.Models.Dto.BackgroundJob;
using ServerNode.Application.Models.Dto.BackgroundJob.Requests;

namespace ServerNode.Infrastructure.Handlers.Queries.BackgroundJob;

public class BackgroundJobReadQueryHandler : IRequestHandler<BackgroundJobReadQuery, BackgroundJobReadOutDto>
{
    public Task<BackgroundJobReadOutDto> Handle(BackgroundJobReadQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}