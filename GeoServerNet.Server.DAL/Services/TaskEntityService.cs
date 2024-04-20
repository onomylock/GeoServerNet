using GeoServerNet.Server.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GeoServerNet.Server.DAL.Services;

public interface ITaskEntityService
{
    Task AddTask(Entities.Task entity, CancellationToken cancellationToken = default);
}

public sealed class TaskEntityService(IDbContextFactory<AppDbContext> dbContextFactory, ILogger<TaskEntityService> logger) : ITaskEntityService
{
    public async Task AddTask(Entities.Task entity, CancellationToken cancellationToken = default)
    {
        var dbContext =  await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await dbContext.Task.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(e, "Add task {Task} to db ", entity);
            throw;
        }
        
    }
}