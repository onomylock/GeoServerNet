using GeoServerNet.Common.Data.Dto.Base;
using MediatR;

namespace GeoServerNet.Application.CQRS.System.Queries;

public record StatusQuery : BaseRequestDto, IRequest<IBaseResponseDto> 
{
    
}

public sealed class StatusQueryHandler : IRequestHandler<StatusQuery, IBaseResponseDto>
{
    public Task<IBaseResponseDto> Handle(StatusQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}