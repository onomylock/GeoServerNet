using Serilog;
using Serilog.Settings.Configuration;
using ServerNode.HttpApi.Extensions;

ConfigureExtensions.InitBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

//STAGE: ConfigureServices
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration, new ConfigurationReaderOptions { SectionName = "Serilog" })
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithAssemblyName()
        .Enrich.WithEnvironmentName()
        .Enrich.WithMachineName()
        .Enrich.WithMemoryUsage()
        .Enrich.WithProcessId()
        .Enrich.WithProcessName()
        .Enrich.WithThreadId()
        .Enrich.WithThreadName();
});

builder.InitServerNodeHttpApi();

var app = builder.Build();

//STAGE: Configure

var logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Environment: {EnvironmentName}", app.Environment.EnvironmentName);

ConfigureExtensions.ConfigureMiddlewarePipeline(app);

try
{
    logger.LogInformation("Application setting is finished...");

    app.Run();

    logger.LogInformation("Application stopping...");
}
catch (Exception e)
{
    logger.LogCritical(e, "An unhandled exception occured during bootstrapping!");
}
finally
{
    logger.LogInformation("Flushing logs...");

    Log.CloseAndFlush();
}