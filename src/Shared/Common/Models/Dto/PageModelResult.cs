namespace Shared.Common.Models.Dto;

public class PageModelResult<T>
{
    public int Total { get; set; }
    public IReadOnlyCollection<T> Items { get; set; }
}