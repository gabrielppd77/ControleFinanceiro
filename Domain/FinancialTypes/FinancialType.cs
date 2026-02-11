using Domain.Base;

namespace Domain.FinancialTypes;

public class FinancialType : Entity
{
    public string Name { get; private set; }

    protected FinancialType() { }

    public FinancialType(string name)
    {
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
    }
}
