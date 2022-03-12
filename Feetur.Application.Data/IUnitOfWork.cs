using Feetur.Application.Data.Entities;

namespace Feetur.Application.Data;

public interface IUnitOfWork
{
    public IRepository<User> UserRepository { get; }

    Task<bool> CompleteAsync();
}