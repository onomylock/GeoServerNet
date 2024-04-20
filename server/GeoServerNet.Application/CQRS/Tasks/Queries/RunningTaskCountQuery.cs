using GeoServerNet.Common.Data.Dto.Base;
using MediatR;

namespace GeoServerNet.Application.CQRS.Tasks.Queries;

public record RunningTaskCountQuery : BaseRequestDto, IRequest<IBaseResponseDto>
{
    
}

public sealed class RunningTaskCountQueryHandler : IRequestHandler<RunningTaskCountQuery, IBaseResponseDto>
{
    public Task<IBaseResponseDto> Handle(RunningTaskCountQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}