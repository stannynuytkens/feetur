using Feetur.Application.Data;
using Feetur.Application.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Feetur.Infrastructure.Data.EF.Memory.Repositories;

public class UserRepository: Repository<User>, IRepository<User>
{
    public UserRepository(DbContext dbContext) : base(dbContext) { }
}