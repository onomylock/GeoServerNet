using System.Reflection;
using FluentValidation;
using GeoServerNet.ApiGetaway.Middleware;
using GeoServerNet.Application.Behaviours;
using GeoServerNet.Server.DAL.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

void AppDbContextOptionsBuilder(DbContextOptionsBuilder options)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connectionString, sqliteOptionsAction =>
    {
        sqliteOptionsAction.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
        sqliteOptionsAction.CommandTimeout(300);
    });
    if (builder.Environment.IsDevelopment()) options.EnableSensitiveDataLogging().EnableDetailedErrors();
}

builder.Services.AddDbContext<AppDbContext>(AppDbContextOptionsBuilder, ServiceLifetime.Scoped, ServiceLifetime.Singleton);

builder.Services.AddDbContextFactory<AppDbContext>(AppDbContextOptionsBuilder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMetricServer();  
app.UseRequestMiddleware();

app.Run();
