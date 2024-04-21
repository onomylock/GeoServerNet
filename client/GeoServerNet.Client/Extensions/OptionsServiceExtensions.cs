using GeoServerNet.Common.Services;
using Microsoft.Extensions.Options;

namespace GeoServerNet.Client.Extensions;

public static class OptionsServiceExtensions
{
    public static IServiceCollection AddWritableOptionsService<T>(
        this IServiceCollection services,
        IConfiguration configuration,
        string filePath)
    {
        var typeName = typeof(T).Name;

        services.AddSingleton<WritableOptionsService<T>>(provider => new WritableOptionsService<T>(
            provider.GetRequiredService<IOptionsMonitor<T>>(), filePath, typeName));

        return services;
    }
}