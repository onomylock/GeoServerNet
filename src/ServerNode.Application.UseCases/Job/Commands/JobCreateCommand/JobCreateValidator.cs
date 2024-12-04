using FluentValidation;

namespace ServerNode.Application.UseCases.Job.Commands.JobCreateCommand;

public class JobCreateValidator : AbstractValidator<JobCreateCommand>
{
    public JobCreateValidator()
    {
        RuleFor(_ => _.Metadata).NotEmpty();
    }
}