using Shared.Common.Models;

namespace Shared.Application.Services;

public interface IWarningService
{
    void AddEntry(WarningModelResultEntry warningModelResultEntry);
    List<WarningModelResultEntry> GetEntries();
}