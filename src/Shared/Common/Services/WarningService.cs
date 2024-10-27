using Shared.Application.Services;
using Shared.Common.Models;

namespace Shared.Common.Services;

public class WarningService : IWarningService
{
    private readonly List<WarningModelResultEntry> _warningModelResultEntries = [];

    public void AddEntry(WarningModelResultEntry warningModelResultEntry)
    {
        _warningModelResultEntries.Add(warningModelResultEntry);
    }

    public List<WarningModelResultEntry> GetEntries()
    {
        return _warningModelResultEntries;
    }
}