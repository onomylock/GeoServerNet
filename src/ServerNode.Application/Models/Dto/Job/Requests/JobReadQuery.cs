using MediatR;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.Job.Requests;

public class JobReadQuery : JobTargetDtoBase, IRequest<JobReadOutDto>, IInDto;