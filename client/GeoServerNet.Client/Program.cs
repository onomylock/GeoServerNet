using GeoServerNet.Client;
using GeoServerNet.Client.Abstraction;
using GeoServerNet.Client.Abstraction.BackgroundServices;
using GeoServerNet.Client.Workers;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ConsumeScopedBackgroundServicesHostedService>();
builder.Services.AddScoped<IScopedBackgroundService, HttpBackgroundService>();



var host = builder.Build();
host.Run();