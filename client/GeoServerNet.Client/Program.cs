using GeoServerNet.Client.Abstraction.BackgroundServices;
using GeoServerNet.Client.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddJsonFile("tasks.json");
builder.Services.AddHostedService<ConsumeScopedBackgroundServicesHostedService>();
builder.Services.AddScoped<IScopedBackgroundService, HttpBackgroundService>();
builder.Services.AddHttpClient();

var host = builder.Build();
host.Run();

