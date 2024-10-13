namespace Shared.Models.DTO.Base;

public interface IErrorModelResult
{
    public List<ErrorModelResultEntry> Errors { get; set; }
}