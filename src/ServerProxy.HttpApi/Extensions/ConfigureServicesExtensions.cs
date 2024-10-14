using Calabonga.Microservices.Tracker.Extensions;
using MediatR;
using Microsoft.OpenApi.Models;
using Shared.Behaviours;

namespace ServerProxy.HttpApi.Extensions;

public static class ConfigureServicesExtensions
{
    public static void InitServerNodeHttpApi(this IHostApplicationBuilder builder)
    {
        builder.Services
            .ConfigureDiOptions(builder.Configuration)
            .ConfigureDiConfigureOptions()
            .ConfigureDiAppDbContext(builder.Environment)
            .ConfigureDiReverseProxy(builder.Configuration)
            .AddHttpContextAccessor()
            .AddHttpClient()
            .AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    TermsOfService = null,
                    Description = $"""
                                   An HTTP API of User backend service [Branch: {builder.Configuration["GIT_BRANCH"] ?? "Unknown"}, Commit: {builder.Configuration["GIT_REV"] ?? "Unknown"}]

                                   For SignalR hubs, connect via <a href="https://www.npmjs.com/package/@microsoft/signalr">@microsoft/signalr</a> (<a href="https://pastebin.com/raw/7qpSm1C1">Example</a>)
                                   """
                });

                swaggerGenOptions.IncludeXmlComments(Path.Join(AppDomain.CurrentDomain.BaseDirectory,
                    "UserService.HttpApi.xml"));

                swaggerGenOptions.EnableAnnotations();
            })
            .ConfigureDiRepositories()
            .ConfigureDiServices()
            .ConfigureDiHandlers()
            .ConfigureDiBackgroundServices()
            .ConfigureHttp()
            .AddCommunicationTracker();
    }

    private static IServiceCollection ConfigureDiRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiReverseProxy(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"));

        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });
        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiBackgroundServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiAppDbContext(
        this IServiceCollection serviceCollection,
        IHostEnvironment env
    )
    {
        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiConfigureOptions(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiOptions(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
    )
    {
        serviceCollection.AddOptions();


        return serviceCollection;
    }

    private static IServiceCollection ConfigureHttp(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}