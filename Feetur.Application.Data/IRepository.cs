using System.Linq.Expressions;

namespace Feetur.Application.Data;

public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity: IEntity<Guid> { }

public interface IRepository<TEntity, TEntityId> where TEntity: IEntity<TEntityId>
{
    Task<TEntity?> GetAsync(TEntityId id, CancellationToken? cancellationToken = null);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken? cancellationToken = null);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken? cancellationToken = null);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken? cancellationToken = null);

    Task UpdateAsync(TEntity entity, CancellationToken? cancellationToken = null);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken = null);

    Task<TEntityId> AddAsync(TEntity entity, CancellationToken? cancellationToken = null);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken = null);

    Task<bool> DeleteAsync(TEntityId id, CancellationToken? cancellationToken = null);
    Task<bool> DeleteAsync(TEntity entity, CancellationToken? cancellationToken = null);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken = null);
}