using Feetur.Application.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

namespace Feetur.Infrastructure.Data.EF.Memory;

public class FeeturDbContext: DbContext
{
    public FeeturDbContext(DbContextOptions<FeeturDbContext> options): base(options) { }

    public DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("memory");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = Guid.NewGuid(),
            Created = DateTime.Now,
            CreatedBy = "Stanny",
            Deleted = false,
            Modified = DateTime.Now.AddDays(1),
            ModifiedBy = "Stanny",
            FirstName = "Stanny",
            LastName = "Nuytkens",
            Email = "stanny@nuytkens.com",
            Active = true
        });
    }
}