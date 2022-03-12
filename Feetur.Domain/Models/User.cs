namespace Feetur.Domain.Models;

public class User
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Email { get; set; }

    public bool Active { get; set; }
}