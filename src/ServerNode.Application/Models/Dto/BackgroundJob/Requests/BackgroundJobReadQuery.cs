using MediatR;

namespace ServerNode.Application.Models.Dto.BackgroundJob.Requests;

public class BackgroundJobReadQuery : BackgroundJobReadInDto, IRequest<BackgroundJobReadOutDto>;