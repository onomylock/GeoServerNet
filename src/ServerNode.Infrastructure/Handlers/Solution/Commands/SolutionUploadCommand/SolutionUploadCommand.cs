using MediatR;
using ServerNode.Application.Models.Dto.Solution;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Infrastructure.Handlers.Solution.Commands.SolutionUploadCommand;

public class SolutionUploadCommand : SolutionRequestDtoBase , IRequest<ResponseBase<SolutionReadDto>>
{
    
}