using Shared.Common.Models.DTO.Base;

namespace Shared.Common.Models;

public sealed class ErrorModelResult : IDtoResultBase
{
    public List<ErrorModelResultEntry> Errors { get; set; } = [];
}