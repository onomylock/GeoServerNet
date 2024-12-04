using MediatR;
using ServerNode.Application.Models.Dto;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.UseCases.Job.Commands.JobDeleteCommand;

public class JobDeleteHandler : IRequestHandler<JobDeleteCommand, ResponseBase<JobDto>>
{
    public Task<ResponseBase<JobDto>> Handle(JobDeleteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}