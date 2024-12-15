using FluentValidation;

namespace ServerNode.Infrastructure.Handlers.Solution.Commands.SolutionDownloadCommand;

public class SolutionDownloadCommandValidator : AbstractValidator<SolutionDownloadCommand>
{
    public SolutionDownloadCommandValidator()
    {
        RuleFor(_ => _.BucketName).NotEmpty().WithMessage("Please specify a valid BucketName");
        RuleFor(_ => _.Path).NotEmpty().WithMessage("Please specify a valid Path");
        RuleFor(_ => _.Metadata).NotEmpty().WithMessage("Please specify a valid Metadata");
    }
}