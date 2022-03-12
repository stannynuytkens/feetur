namespace Feetur.Application.Data;

public interface IAuditedEntity<TEntityId>: IEntity<TEntityId>
{
    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public string CreatedBy { get; set; }

    public string ModifiedBy { get; set; }

    public bool Deleted { get; set; }
}