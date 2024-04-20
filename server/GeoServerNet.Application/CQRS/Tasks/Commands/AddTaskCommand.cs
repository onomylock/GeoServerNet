using FluentValidation;
using GeoServerNet.Application.Services;
using GeoServerNet.Common.Data.Dto;
using GeoServerNet.Common.Data.Dto.Base;
using MediatR;

namespace GeoServerNet.Application.CQRS.Tasks.Commands;

public record AddTaskCommand : BaseRequestDto, IRequest<IBaseResponseDto>
{
    public int TaskId { get; set; }
    public required IEnumerable<DependencyDto> DependencyCollectionDto { get; set; }
}

public sealed class AddTaskCommandHandler(ITaskService taskService) : IRequestHandler<AddTaskCommand, IBaseResponseDto>
{
    public async Task<IBaseResponseDto> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        await taskService.AddNewTask(request.TaskId, request.DependencyCollectionDto, cancellationToken);
        return new OkResponseDto();
    }
}

public class AddTaskValidator : AbstractValidator<AddTaskCommand>
{
    public AddTaskValidator()
    {
        RuleFor(c => c.TaskId).NotEmpty();
        RuleFor(c => c.DependencyCollectionDto).NotEmpty();
    }
}
