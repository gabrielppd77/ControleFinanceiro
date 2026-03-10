using Domain.Base;
using Domain.Classifications;
using Domain.FinancialTypes;
using Domain.Users;

namespace Domain.FinancialEntries;

public class FinancialEntry : Entity
{
    public DateTime Date { get; protected set; }
    public decimal Amount { get; protected set; }
    public string? Description { get; protected set; }
    public Guid UserId { get; protected set; }
    public Guid TypeId { get; protected set; }
    public Guid ClassificationId { get; protected set; }

    public User User { get; protected set; }
    public FinancialType Type { get; protected set; }
    public Classification Classification { get; protected set; }

    protected FinancialEntry() { }

    public FinancialEntry(DateTime date, decimal amount, Guid typeId, Guid classificationId, string? description, Guid userId)
    {
        Date = date;
        Amount = amount;
        TypeId = typeId;
        ClassificationId = classificationId;
        Description = description;
        UserId = userId;
    }

    public void Update(DateTime date, decimal amount, Guid typeId, Guid classificationId, string? description)
    {
        Date = date;
        Amount = amount;
        TypeId = typeId;
        ClassificationId = classificationId;
        Description = description;
    }
}
