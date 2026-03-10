using Domain.Base;
using Domain.Users;

namespace Domain.Classifications;

public class Classification : Entity
{
    public string Name { get; protected set; }
    public Guid UserId { get; protected set; }

    public User User { get; protected set; }

    protected Classification() { }

    public Classification(string name, Guid userId)
    {
        Name = name;
        UserId = userId;
    }

    public void Update(string name)
    {
        Name = name;
    }
}
