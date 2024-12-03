using Shared.Common.Models;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.Job;

public class JobReadCollectionOutDto : JobReadCollectionBaseOutDto, IOutDtoBase
{
    public List<ErrorModelResultEntry> Errors { get; set; }
    public List<WarningModelResultEntry> Warnings { get; set; }
}