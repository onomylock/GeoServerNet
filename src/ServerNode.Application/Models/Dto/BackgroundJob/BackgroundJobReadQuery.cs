using MediatR;

namespace ServerNode.Application.Models.Dto.BackgroundJob;

public class BackgroundJobReadQuery : IRequest<BackgroundJobReadResponse>
{
    public int JobId { get; set; }
}