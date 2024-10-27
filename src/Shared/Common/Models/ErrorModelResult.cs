using Shared.Common.Models.DTO.Base;

namespace Shared.Common.Models;

public sealed class ErrorModelResult : IOutDtoBase, IErrorModelResult
{
    public List<ErrorModelResultEntry> Errors { get; set; } = [];
    public List<WarningModelResultEntry> Warnings { get; set; }
}