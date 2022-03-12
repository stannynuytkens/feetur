namespace Feetur.Application.Data.Entities;

public class BaseEntity<TEntityId>: IAuditedEntity<TEntityId>
{
    public TEntityId Id { get; set; }
    
    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public string CreatedBy { get; set; }

    public string ModifiedBy { get; set; }

    public bool Deleted { get; set; }
}

public class BaseEntity: BaseEntity<Guid> { }