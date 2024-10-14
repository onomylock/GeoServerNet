using Calabonga.Microservices.Tracker.Extensions;
using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Shared.Behaviours;
using Shared.Models.Options;

namespace ServerNode.HttpApi.Extensions;

public static class ConfigureServicesExtensions
{
    public static void InitServerNodeHttpApi(this IHostApplicationBuilder builder)
    {
        builder.Services
            .ConfigureDiOptions(builder.Configuration)
            .ConfigureDiConfigureOptions()
            .ConfigureDiAppDbContext(builder.Environment)
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

    private static IServiceCollection ConfigureDiHangfire(
        this IServiceCollection serviceCollection,
        IHostEnvironment env
    )
    {
        serviceCollection
            .AddHangfire((provider, globalConfiguration) =>
            {
                var hangfireOptions = provider.GetRequiredService<IOptions<HangfireOptions>>().Value;
                var hangfireDbContextOptions = hangfireOptions.DbContextOptions;

                var connectionString = hangfireDbContextOptions.ConnectionString +
                                       (!env.IsProduction() ? ";Include Error Detail=true" : "");

                globalConfiguration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UsePostgreSqlStorage(options => options.UseNpgsqlConnection(connectionString),
                        new PostgreSqlStorageOptions
                        {
                            QueuePollInterval = TimeSpan.FromSeconds(hangfireOptions.QueuePollIntervalSeconds)
                        });
            });

        serviceCollection.AddHangfireServer(options =>
            options.ServerName = $"{Environment.MachineName}");

        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiOptions(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
    )
    {
        serviceCollection.AddOptions();

        serviceCollection.AddOptions<HangfireOptions>().Bind(configuration.GetSection(nameof(HangfireOptions)))
            .ValidateDataAnnotations().ValidateOnStart();

        return serviceCollection;
    }

    private static IServiceCollection ConfigureHttp(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}