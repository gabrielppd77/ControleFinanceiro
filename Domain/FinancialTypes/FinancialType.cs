using Domain.Base;
using Domain.Users;

namespace Domain.FinancialTypes;

public class FinancialType : Entity
{
    public string Name { get; protected set; }
    public string? Color { get; protected set; }
    public Guid UserId { get; protected set; }

    public User User { get; protected set; }

    protected FinancialType() { }

    public FinancialType(string name, string? color, Guid userId)
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
