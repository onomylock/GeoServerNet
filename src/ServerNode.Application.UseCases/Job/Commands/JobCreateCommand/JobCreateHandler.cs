using System.Diagnostics;
using FluentValidation;
using MediatR;
using ServerNode.Application.Models.Dto;
using Shared.Application.Services;
using Shared.Common.Helpers;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.UseCases.Job.Commands.JobCreateCommand;

public class JobCreateHandler(
    IJobService jobService,
    IValidator<JobCreateCommand> validator
) : IRequestHandler<JobCreateCommand, ResponseBase<JobDto>>
{
    public async Task<ResponseBase<JobDto>> Handle(JobCreateCommand request, CancellationToken cancellationToken)
    {
        var result = new ResponseBase<JobDto>();
        
        try
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var startupInfo = await ProcessHelper.GetProcessStartInfoAsync(request.Metadata);
        
            var targetBackgroundJobId = jobService.AddEnque(() => Process.Start(startupInfo));

            result.Data = new JobDto { JobId = targetBackgroundJobId };
        }
        catch (Exception e)
        {
            result.Message = e.Message;
        }

        return result;
    }
}