using MediatR;
using ServerNode.Application.Models.Dto.BackgroundJob;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Queries.BackgroundJob;

public class BackgroundJobReadQueryHandler : IRequestHandler<BackgroundJobReadQuery, IResponseDto>
{
    public Task<IResponseDto> Handle(BackgroundJobReadQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}