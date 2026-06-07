using Domain.Base;
using Domain.Users;

namespace Domain.FinancialAccounts;

public class FinancialAccount : Entity
{
    public string Name { get; protected set; }
    public string? Color { get; protected set; }
    public Guid UserId { get; protected set; }
    public User User { get; protected set; }

    protected FinancialAccount() { }

    public FinancialAccount(string name, string? color, Guid userId)
    {
        Name = name;
        Color = color;
        UserId = userId;
    }

    public void Update(string name, string? color)
    {
        Name = name;
        Color = color;
    }
}
