using MediatR;
using ServerNode.Application.Models.Dto.BackgroundJob.Requests;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Commands.BackgroundJob;

public class BackgroundJobCreateCommandHandler : IRequestHandler<BackgroundJobCreateCommand, IOutDtoBase>
{
    public Task<IOutDtoBase> Handle(BackgroundJobCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}