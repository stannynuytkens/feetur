namespace Feetur.Application.Data.Entities;

public class Entity<TEntityId>: IEntity<TEntityId>
{
    public TEntityId Id { get; set; }
    
    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public User CreatedBy { get; set; }

    public User ModifiedBy { get; set; }

    public bool Deleted { get; set; }
}

public class Entity: Entity<Guid> { }