using GeoServerNet.Server.DAL.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Task = GeoServerNet.Server.DAL.Entities.Task;

namespace GeoServerNet.Server.DAL.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        ((SqliteConnection)Database.GetDbConnection()).DefaultTimeout = 300;
    }
    
    public DbSet<Task> Task { get; set; }
    public DbSet<Dependency> Dependency { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Task>()
            .HasMany(e => e.Dependencies)
            .WithOne()
            .HasForeignKey(e => e.TaskId)
            .IsRequired();
    }
}