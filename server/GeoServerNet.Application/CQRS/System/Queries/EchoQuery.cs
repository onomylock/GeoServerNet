using GeoServerNet.Common.Data.Dto.Base;
using MediatR;

namespace GeoServerNet.Application.CQRS.System.Queries;

public record EchoQuery: BaseRequestDto, IRequest<IBaseResponseDto>
{
    
}

public sealed class EchoQueryHandler : IRequestHandler<EchoQuery, IBaseResponseDto>
{
    public Task<IBaseResponseDto> Handle(EchoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}