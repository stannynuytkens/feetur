using System.Linq.Expressions;

namespace Feetur.Application.Data;

public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity: IEntity<Guid> { }

public interface IRepository<TEntity, TEntityId> where TEntity: IEntity<TEntityId>
{
    Task<TEntity?> Get(Guid id);
    Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity?> Update(TEntity entity);
    Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities);

    Task Add(TEntity entity);
    Task AddRange(IEnumerable<TEntity> entities);

    Task Delete(TEntity entity);
    Task DeleteRange(IEnumerable<TEntity> entities);
}