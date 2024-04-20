using GeoServerNet.Common.Data.Dto.Base;
using MediatR;

namespace GeoServerNet.Application.CQRS.Tasks.Queries;

public record ListTasksQuery : BaseRequestDto, IRequest<IBaseResponseDto>
{
    
}

public sealed class ListTasksQueryHandler : IRequestHandler<ListTasksQuery, IBaseResponseDto>
{
    public Task<IBaseResponseDto> Handle(ListTasksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}