using Domain.Base;

namespace Domain.Classifications;

public class Classification: Entity
{
    public string Name { get; private set; }

    protected Classification() { }
}
