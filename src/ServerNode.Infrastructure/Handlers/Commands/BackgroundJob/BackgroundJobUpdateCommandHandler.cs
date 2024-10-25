using MediatR;
using ServerNode.Application.Models.Dto.BackgroundJob.Requests;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Commands.BackgroundJob;

public class BackgroundJobUpdateCommandHandler : IRequestHandler<BackgroundJobUpdateCommand, IOutDtoBase>
{
    public Task<IOutDtoBase> Handle(BackgroundJobUpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}