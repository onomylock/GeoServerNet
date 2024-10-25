using Shared.Common.Enums;

namespace Shared.Common.Models;

public sealed class WarningModelResultEntry(
    WarningType warningType,
    string message,
    WarningEntryType warningEntryType = WarningEntryType.None)
{
    public WarningType WarningType { get; } = warningType;
    public string Message { get; } = message;
    public WarningEntryType WarningEntryType { get; } = warningEntryType;
}