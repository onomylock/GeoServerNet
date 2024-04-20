using GeoServerNet.Common.Data.Dto.Base;
using MediatR;

namespace GeoServerNet.Application.CQRS.System.Queries;

public record VersionQuery : BaseRequestDto, IRequest<IBaseResponseDto>
{
    
}

public sealed class VersionQueryHandler : IRequestHandler<VersionQuery, IBaseResponseDto>
{
    public Task<IBaseResponseDto> Handle(VersionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}