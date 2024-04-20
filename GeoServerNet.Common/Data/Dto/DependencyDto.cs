using GeoServerNet.Common.Enums;

namespace GeoServerNet.Common.Data.Dto;

public record DependencyDto
{
    public required string ServerName { get; set; }
    public required string ClientName { get; set; }
    public required DependencyType DependencyType { get; set; }
}