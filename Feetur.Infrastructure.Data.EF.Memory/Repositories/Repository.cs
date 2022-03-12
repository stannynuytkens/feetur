using System.Linq.Expressions;
using Feetur.Application.Data;
using Feetur.Application.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Feetur.Infrastructure.Data.EF.Memory.Repositories;

public abstract class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>
    where TEntity : class, IEntity<TEntityId>, new()
{
    private readonly DbContext _dbContext;
    
    protected Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    Task<TEntity?> IRepository<TEntity, TEntityId>.GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken? cancellationToken) 
        => Get(predicate, cancellationToken);
    Task<IEnumerable<TEntity>> IRepository<TEntity, TEntityId>.GetAllAsync(CancellationToken? cancellationToken)
        => GetAll(cancellationToken);
    Task<IEnumerable<TEntity>> IRepository<TEntity, TEntityId>.GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken? cancellationToken)
        => GetAll(predicate, cancellationToken);
    Task IRepository<TEntity, TEntityId>.UpdateAsync(TEntity entity, CancellationToken? cancellationToken) 
        => Update(entity, cancellationToken);
    Task IRepository<TEntity, TEntityId>.UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken)
        => UpdateRange(entities, cancellationToken);
    Task<TEntityId> IRepository<TEntity, TEntityId>.AddAsync(TEntity entity, CancellationToken? cancellationToken)
        => Add(entity, cancellationToken);
    Task IRepository<TEntity, TEntityId>.AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken)
        => AddRange(entities, cancellationToken);
    Task<bool> IRepository<TEntity, TEntityId>.DeleteAsync(TEntityId id, CancellationToken? cancellationToken)
        => Delete(id, cancellationToken);
    Task<bool> IRepository<TEntity, TEntityId>.DeleteAsync(TEntity entity, CancellationToken? cancellationToken)
        => Delete(entity, cancellationToken);
    Task IRepository<TEntity, TEntityId>.DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken)
        => DeleteRange(entities, cancellationToken);
    Task<TEntity?> IRepository<TEntity, TEntityId>.GetAsync(TEntityId id, CancellationToken? cancellationToken)
        => Get(id, cancellationToken);

    protected virtual async Task<TEntity?> Get(TEntityId id, CancellationToken? cancellationToken)
        => await _dbContext.FindAsync<TEntity>(id, cancellationToken);

    protected virtual async Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken? cancellationToken)
        => await _dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate, cancellationToken ?? default(CancellationToken));

    protected virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken? cancellationToken)
        => await _dbContext.Set<TEntity>().ToListAsync(cancellationToken ?? default(CancellationToken));

    protected virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, CancellationToken? cancellationToken)
        => await _dbContext.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken ?? default(CancellationToken));

    protected virtual async Task Update(TEntity entity, CancellationToken? cancellationToken)
        => await Task.Factory.StartNew(() => _dbContext.Update(entity), cancellationToken ?? default(CancellationToken));

    protected virtual async Task UpdateRange(IEnumerable<TEntity> entities, CancellationToken? cancellationToken)
        => await Task.Factory.StartNew(() => _dbContext.UpdateRange(entities), cancellationToken ?? default(CancellationToken));

    protected virtual async Task<TEntityId> Add(TEntity entity, CancellationToken? cancellationToken)
        => (await _dbContext.AddAsync(entity, cancellationToken ?? default(CancellationToken))).Entity.Id;

    protected virtual async Task AddRange(IEnumerable<TEntity> entities, CancellationToken? cancellationToken)
        => await _dbContext.AddRangeAsync(entities, cancellationToken ?? default(CancellationToken));

    protected virtual async Task<bool> Delete(TEntityId id, CancellationToken? cancellationToken)
    {
        var entity = await Get(id, cancellationToken);
        if (entity != null)
            return await Delete(entity, cancellationToken);

        return false;
    }
    
    protected virtual async Task<bool> Delete(TEntity entity, CancellationToken? cancellationToken)
        => await Task.Factory.StartNew(() => _dbContext.Remove(entity), cancellationToken ?? default(CancellationToken)).ContinueWith(
            t => t.IsCompletedSuccessfully);

    protected virtual async Task DeleteRange(IEnumerable<TEntity> entities, CancellationToken? cancellationToken)
        => await Task.Factory.StartNew(() => _dbContext.RemoveRange(entities), cancellationToken ?? default(CancellationToken));
}

public class Repository<TEntity>: Repository<TEntity, Guid>
    where TEntity: class, IEntity<Guid>, new()
{
    protected Repository(DbContext dbContext) : base(dbContext) { }
}