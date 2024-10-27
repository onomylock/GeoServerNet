using Shared.Common.Models.DTO.Base;

namespace Shared.Common.Models.Dto.Generic;

/// <summary>
///     Special model dto, used to respond with a streamed file
/// </summary>
/// <remarks>Stream must be of type FileStream to support Partial data request via 206 HTTP.<br />Otherwise, download of data would be fully-sequential</remarks>
public class FileOutDto : IOutDtoBase
{
    public Stream Stream { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public List<WarningModelResultEntry> Warnings { get; set; }
}