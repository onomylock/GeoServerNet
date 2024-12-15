using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerNode.Application.Models.Dto.Solution;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Solution.Commands.SolutionDeleteCommand;

public class SolutionDeleteCommand : SolutionTargetDtoBase, IRequest<ResponseBase<OkResult>>;