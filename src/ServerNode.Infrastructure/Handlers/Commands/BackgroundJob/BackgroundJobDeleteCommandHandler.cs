using MediatR;
using ServerNode.Application.Models.Dto.BackgroundJob.Requests;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Commands.BackgroundJob;

public class BackgroundJobDeleteCommandHandler : IRequestHandler<BackgroundJobDeleteCommand, IOutDtoBase>
{
    public Task<IOutDtoBase> Handle(BackgroundJobDeleteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}