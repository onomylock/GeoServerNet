using MediatR;

namespace ServerNode.Application.Models.Dto.BackgroundJob.Requests;

public class BackgroundJobCreateCommand : BackgroundJobCreateInDto, IRequest<BackgroundJobReadOutDto>;