namespace Feetur.Application.Data.Entities;

public class User: IEntity<Guid>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Email { get; set; }

    public bool Active { get; set; }
}