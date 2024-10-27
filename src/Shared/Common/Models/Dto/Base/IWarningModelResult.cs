namespace Shared.Common.Models.DTO.Base;

public interface IWarningModelResult
{
    public List<WarningModelResultEntry> Warnings { get; set; }
}