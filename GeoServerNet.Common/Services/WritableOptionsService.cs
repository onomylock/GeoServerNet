using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
using GeoServerNet.Common.Helpers;
using Microsoft.Extensions.Options;

namespace GeoServerNet.Common.Services;

public interface IWritableOptionsService<TOptions>
{
    TOptions CurrentValue { get; }
    string Section { get; }
    TOptions Get(string name);
    public event Action<TOptions, string> Change;
    Task UpdateValue(TOptions options, CancellationToken cancellationToken = default);
}

public sealed class WritableOptionsService<TOptions>(
    IOptionsMonitor<TOptions> optionsMonitor,
    string filePath,
    string rootSection)
    : IWritableOptionsService<TOptions>, IDisposable
{
    public void Dispose()
    {
        var subscribers = Change?.GetInvocationList();
        if (subscribers is { })
            foreach (var subscriber in subscribers)
                Change -= subscriber as Action<TOptions, string>;
    }
    
    /// <summary>
    ///     Returns the current <typeparamref name="TOptions" /> instance with the <see cref="Options.DefaultName" />.
    /// </summary>
    public TOptions CurrentValue => optionsMonitor.CurrentValue;
    
    /// <summary>
    ///     Returns a configured <typeparamref name="TOptions" /> instance with the given name.
    /// </summary>
    public TOptions Get(string name)
    {
        return optionsMonitor.Get(name);
    }
    
    /// <summary>
    ///     Invoked when change occurs.
    /// </summary>
    public event Action<TOptions, string> Change;
    
    /// <summary>
    ///     Updates section configuration file.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task UpdateValue(TOptions options, CancellationToken cancellationToken = default)
    {
        var fileInfo = new FileInfo(filePath);
        
        if (!File.Exists(fileInfo.FullName))
            throw new FileNotFoundException(fileInfo.FullName);
        
        var fileData = await File.ReadAllBytesAsync(fileInfo.FullName, cancellationToken);
        
        var jsonRootNode = JsonNode.Parse(fileData) ?? throw new SerializationException();
        
        var jsonSerializeOptions = JsonHelper.GetDefaultOptions();
        
        jsonRootNode[Section] = JsonSerializer.SerializeToNode(options, jsonSerializeOptions);
        
        var ms = new MemoryStream();
        await JsonSerializer.SerializeAsync(ms, jsonRootNode, jsonSerializeOptions, cancellationToken);
        ms.Seek(0, SeekOrigin.Begin);
        
        await File.WriteAllBytesAsync(fileInfo.FullName, ms.ToArray(), cancellationToken);
        
        //Manually invoke OnChangeListener
        OnChangeListener(options, null);
    }
    
    /// <summary>
    ///     Returns section name
    /// </summary>
    public string Section { get; }
    
    private void OnChangeListener(TOptions options, string s)
    {
        Change?.Invoke(options, s);
    }
}