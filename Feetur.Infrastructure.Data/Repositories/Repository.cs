using System.Linq.Expressions;
using Feetur.Application.Data;

namespace Feetur.Infrastructure.Data.Repositories;

public abstract class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId> where TEntity : IEntity<TEntityId>
{
    public virtual Task<TEntity?> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<TEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity?> Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public virtual Task Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task AddRange(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public virtual Task Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task DeleteRange(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}

public class Repository<TEntity>: Repository<TEntity, Guid> where TEntity: IEntity<Guid> { }