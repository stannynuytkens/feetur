namespace Feetur.Application.Data;

public interface IEntity<TEntityId>
{
    TEntityId Id { get; set; }
}