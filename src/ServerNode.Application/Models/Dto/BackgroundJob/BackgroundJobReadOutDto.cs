using Shared.Common.Models;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.BackgroundJob;

public class BackgroundJobReadOutDto : BackgroundJobReadBaseOutDto, IOutDtoBase
{
    public List<ErrorModelResultEntry> Errors { get; set; }
    public List<WarningModelResultEntry> Warnings { get; set; }
    public string TraceId { get; set; }
}