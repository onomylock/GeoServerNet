using System.Diagnostics;
using System.Text.Json.Serialization;
using Calabonga.Microservices.Tracker.Extensions;
using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Shared.Application.Services;
using Shared.Common.Behaviours;
using Shared.Common.Enums;
using Shared.Common.Models;
using Shared.Common.Models.Options;
using Shared.Common.Services;

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
            .AddRateLimiter(o => o
                .AddFixedWindowLimiter(policyName: "fixed", options =>
                {
                    // configuration
                }))
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
            .ConfigureHttp()
            .ConfigureDiHangfire(builder.Environment)
            .AddCommunicationTracker();
    }

    private static IServiceCollection ConfigureDiRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    private static IServiceCollection ConfigureDiServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        serviceCollection.AddScoped<IWarningService, WarningService>();

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
        serviceCollection
            .Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
            {
                // options.SuppressModelStateInvalidFilter = true;
                apiBehaviorOptions.InvalidModelStateResponseFactory = context =>
                {
                    var errorModelResult = new ErrorModelResult();

                    foreach (var modelError in context.ModelState.Values.SelectMany(modelStateValue => modelStateValue.Errors))
                        errorModelResult.Errors.Add(new ErrorModelResultEntry(ErrorType.ModelState, modelError.ErrorMessage));

                    return new BadRequestObjectResult(errorModelResult);
                };
            });

        serviceCollection
            .AddMvc()
            .ConfigureApiBehaviorOptions(apiBehaviorOptions =>
            {
                // options.SuppressModelStateInvalidFilter = true;
                apiBehaviorOptions.InvalidModelStateResponseFactory = context =>
                {
                    var errorModelResult = new ErrorModelResult();

                    foreach (var modelError in context.ModelState.Values.SelectMany(modelStateValue => modelStateValue.Errors))
                        errorModelResult.Errors.Add(new ErrorModelResultEntry(ErrorType.ModelState, modelError.ErrorMessage));

                    return new BadRequestObjectResult(errorModelResult);
                };
            });

        serviceCollection
            .AddControllers()
            .AddControllersAsServices()
            .AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                jsonOptions.JsonSerializerOptions.IncludeFields = true;
                jsonOptions.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
                jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        
        return serviceCollection;
    }
}