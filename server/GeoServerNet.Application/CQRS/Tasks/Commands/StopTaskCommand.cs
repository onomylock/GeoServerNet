using GeoServerNet.Common.Data.Dto.Base;
using MediatR;

namespace GeoServerNet.Application.CQRS.Tasks.Commands;

public record StopTaskCommand : BaseRequestDto, IRequest<IBaseResponseDto>
{
    public required int TaskId { get; set; } 
}

public sealed class StopTaskCommandHandler : IRequestHandler<StopTaskCommand, IBaseResponseDto>
{
    public Task<IBaseResponseDto> Handle(StopTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}