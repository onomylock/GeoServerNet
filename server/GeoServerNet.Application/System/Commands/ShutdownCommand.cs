using GeoServerNet.Common.Data.Dto.Base;
using MediatR;

namespace GeoServerNet.Application.System.Commands;

public record ShutdownCommand : IRequest<IBaseResponseDto>
{
    
}

public sealed class 