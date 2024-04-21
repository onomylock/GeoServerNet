namespace GeoServerNet.Client.Options;

public record UpdateDelayOptions
{
    public int UpdateHttpClientDelaySeconds { get; set; }
}