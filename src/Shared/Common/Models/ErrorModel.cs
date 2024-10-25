using Shared.Common.Models.DTO.Base;

namespace Shared.Common.Models;

public sealed class ErrorModel : IOutDtoBase
{
    public List<ErrorModelResultEntry> Errors { get; set; } = [];
}