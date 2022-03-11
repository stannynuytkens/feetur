namespace Feetur.Application.Data.Entities;

public class Application: Entity
{
    public string Name { get; set; }

    public User Owner { get; set; }

    public bool Active { get; set; }
}