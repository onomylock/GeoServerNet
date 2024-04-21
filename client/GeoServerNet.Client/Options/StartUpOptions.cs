using System.Text.Json.Serialization;

namespace GeoServerNet.Client.Options;

public record StartUpOptions
{
    [JsonPropertyName("maxRunning")]
    public int MaxRunning { get; set; }
    [JsonPropertyName("failThreshold")]
    public int FailThreshold { get; set; }
    [JsonPropertyName("servers")] 
    public string[] Servers { get; set; } = [];
    [JsonPropertyName("tasks")] 
    public TaskOptions[] TaskOptions { get; set; } = [];
}