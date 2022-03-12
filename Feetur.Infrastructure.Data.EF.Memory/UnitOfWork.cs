using Feetur.Application.Data;
using Feetur.Application.Data.Entities;
using Feetur.Application.Logging;
using Feetur.Infrastructure.Data.EF.Memory.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Feetur.Infrastructure.Data.EF.Memory;

/// <summary>
/// An <see cref="IUnitOfWork"/> implementation for SQLite
/// </summary>
/// <remarks>https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli</remarks>
public class UnitOfWork: IUnitOfWork
{
    private readonly DbContext _dbContext = new FeeturDbContext(new DbContextOptions<FeeturDbContext>());
    private readonly ILog _log;

    public UnitOfWork(ILog log)
    {
        _log = log;
        _dbContext.Database.EnsureCreated();
    }
    
    private IRepository<User>? _userRepository;
    public IRepository<User> UserRepository => _userRepository ??= new UserRepository(_dbContext);
    
    public async Task<bool> CompleteAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            await _log.Error(e.Message, e);
            
            return false;
        }
    }
}