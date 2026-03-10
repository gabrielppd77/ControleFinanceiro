using Domain.Base;
using Domain.Users;

namespace Domain.FinancialTypes;

public class FinancialType : Entity
{
    public string Name { get; protected set; }
    public Guid UserId { get; protected set; }

    public User User { get; protected set; }

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
