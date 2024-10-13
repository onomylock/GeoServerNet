using Shared.Models.DTO.Base;

namespace Shared.Models;

public sealed class ErrorModelResult : IDtoResultBase
{
    public List<ErrorModelResultEntry> Errors { get; set; } = [];
}