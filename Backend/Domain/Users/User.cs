using Domain.Base;

namespace Domain.Users;

public class User : Entity
{
    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }

    public User()
    {
    }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
