using Domain.Base;
using Domain.FinancialTypes;
using Domain.Users;

namespace Domain.FinancialEntries;

public class FinancialEntry : Entity
{
    public DateTime Date { get; protected set; }
    public decimal Amount { get; protected set; }
    public ClassificationEnum Classification { get; protected set; }
    public string? Description { get; protected set; }
    public Guid UserId { get; protected set; }
    public User User { get; protected set; }
    public Guid TypeId { get; protected set; }
    public FinancialType Type { get; protected set; }

    protected FinancialEntry() { }

    public FinancialEntry(DateTime date, decimal amount, ClassificationEnum classification, Guid userId, Guid typeId, string? description)
    {
        Date = date;
        Amount = amount;
        Classification = classification;
        UserId = userId;
        TypeId = typeId;
        Description = description;
    }

    public void Update(DateTime date, decimal amount, ClassificationEnum classification, Guid typeId, string? description)
    {
        Date = date;
        Amount = amount;
        Classification = classification;
        TypeId = typeId;
        Description = description;
    }
}
