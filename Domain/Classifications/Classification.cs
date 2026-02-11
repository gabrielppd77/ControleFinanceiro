using Domain.Base;

namespace Domain.Classifications;

public class Classification : Entity
{
    public string Name { get; private set; }

    protected Classification() { }

    public Classification(string name)
    {
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
    }
}
