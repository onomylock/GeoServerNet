using System.Diagnostics;
using FluentValidation;
using MediatR;
using ServerNode.Application.Models.Dto.Job;
using ServerNode.Application.Models.Dto.Job.Requests;
using Shared.Application.Services;
using Shared.Common.Helpers;

namespace ServerNode.Infrastructure.Handlers.Commands.Job;

public class JobCreateCommandHandler(
    IJobService jobService,
    IValidator<JobCreateCommand> validator
) : IRequestHandler<JobCreateCommand, JobReadOutDto>
{
    public async Task<JobReadOutDto> Handle(JobCreateCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var startupInfo = await ProcessHelper.GetProcessStartInfoAsync(request.Metadata);
        
        var targetBackgroundJobId = jobService.AddEnque(() => Process.Start(startupInfo));

        return new JobReadOutDto
        {
            JobId = targetBackgroundJobId
        };
    }
}