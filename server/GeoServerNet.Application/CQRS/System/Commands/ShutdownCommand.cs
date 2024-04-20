using GeoServerNet.Common.Data.Dto;
using GeoServerNet.Common.Data.Dto.Base;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GeoServerNet.Application.CQRS.System.Commands;

public record ShutdownCommand : BaseRequestDto, IRequest<IBaseResponseDto>
{
    
}

public sealed class ShutdownCommandHandler(ILogger<ShutdownCommandHandler> logger, IHostLifetime lifetime)
    : IRequestHandler<ShutdownCommand, IBaseResponseDto>
{
    public async Task<IBaseResponseDto> Handle(ShutdownCommand request, CancellationToken cancellationToken)
    {
        await lifetime.StopAsync(cancellationToken);
        return new OkResponseDto();
    }
}