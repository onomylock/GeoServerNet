using Shared.Enums;

namespace Shared.Common.Models;

public sealed class ErrorModelResultEntry(
    ErrorType errorType,
    string message,
    ErrorEntryType errorEntryType = ErrorEntryType.None)
{
    public ErrorType ErrorType { get; } = errorType;
    public string Message { get; } = message;
    public ErrorEntryType ErrorEntryType { get; } = errorEntryType;
}