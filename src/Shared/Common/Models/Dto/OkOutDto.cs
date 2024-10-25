using Shared.Common.Models.DTO.Base;

namespace Shared.Common.Models.Dto;

/// <summary>
///     Default dto model to use for respond on success
/// </summary>
public class OkOutDto : IOutDtoBase
{
    public List<WarningModelResultEntry> Warnings { get; set; }
    public List<ErrorModelResultEntry> Errors { get; set; }
}