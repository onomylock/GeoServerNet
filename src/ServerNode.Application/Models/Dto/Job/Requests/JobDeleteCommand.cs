using MediatR;
using Shared.Common.Models.Dto;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.Job.Requests;

public class JobDeleteCommand : JobTargetDtoBase, IInDto, IRequest<OkOutDto>;