using System.Text.Json.Serialization;

namespace GeoServerNet.Client.Options;

public record TaskOptions
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TaskStatus TaskStatus { get; set; }
    
    [JsonPropertyName("priority")]
    public int Priority { get; set; }
    
    [JsonPropertyName("arguments")] 
    public string[] Arguments { get; set; } = [];

    [JsonPropertyName("executable")]
    public string? Executable { get; set; }
    
    [JsonPropertyName("dependencies")] 
    public Dictionary<string, string> Dependencies { get; set; } = [];
    
    [JsonPropertyName("results")]
    public Dictionary<string, string> Results { get; set; } = [];
    
    [JsonPropertyName("resultFileLists")]
    public Dictionary<string, string> ResultFileLists { get; set; } = [];
    
    
}