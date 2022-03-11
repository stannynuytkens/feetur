using Feetur.Application.Data;
using Feetur.Application.Data.Entities;
using Feetur.Infrastructure.Data.Repositories;

namespace Feetur.Infrastructure.Data.SQLite;

/// <summary>
/// An <see cref="IUnitOfWork"/> implementation for SQLite
/// </summary>
/// <remarks>https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli</remarks>
public class UnitOfWork: IUnitOfWork
{
    private IRepository<User>? _userRepository;
    public IRepository<User> UserRepository => _userRepository ??= new UserRepository();
    
    private IRepository<Feature<bool>>? _featureRepository;
    public IRepository<Feature<bool>> FeatureRepository => _featureRepository ??= new FeatureRepository();
    public async Task<bool> Complete()
    {
        return await Task.FromResult(true);
    }
}