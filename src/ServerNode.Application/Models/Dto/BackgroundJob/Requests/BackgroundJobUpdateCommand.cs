using MediatR;
using Shared.Common.Models.Dto;

namespace ServerNode.Application.Models.Dto.BackgroundJob.Requests;

public class BackgroundJobUpdateCommand : BackgroundJobUpdateInDto, IRequest<OkOutDto>;