using MediatR;
using ServerNode.Application.Models.Dto;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.UseCases.Job.Commands.JobDeleteCommand;

public class JobDeleteCommand : IRequest<ResponseBase<JobDto>>;