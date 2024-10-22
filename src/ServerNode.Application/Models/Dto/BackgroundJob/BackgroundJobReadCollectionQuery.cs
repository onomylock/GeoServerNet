using MediatR;
using Shared.Common.Models.Dto;

namespace ServerNode.Application.Models.Dto.BackgroundJob;

public class BackgroundJobReadCollectionQuery : IRequest<PageModelResult<BackgroundJobReadResponse>>
{
    
}