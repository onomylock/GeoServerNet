using Shared.Common.Models;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.Job;

public class JobReadOutDto : JobReadBaseOutDto, IOutDtoBase
{
    public List<ErrorModelResultEntry> Errors { get; set; }
    public List<WarningModelResultEntry> Warnings { get; set; }
}