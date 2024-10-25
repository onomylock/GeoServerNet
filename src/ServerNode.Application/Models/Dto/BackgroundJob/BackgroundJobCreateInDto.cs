using Shared.Common.Models.DTO.Base;
using Shared.Domain.View;

namespace ServerNode.Application.Models.Dto.BackgroundJob;

public class BackgroundJobCreateInDto : IInDto
{
    public KeyValueEntry Metadata { get; set; }
    public string Uri { get; set; } 
}