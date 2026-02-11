using Domain.Base;
using Domain.Classifications;
using Domain.FinancialTypes;

namespace Domain.FinancialEntries;

public class FinancialEntry : Entity
{
    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public FinancialType Type { get; private set; }
    public Classification Classification { get; private set; }
    public string? Description { get; private set; }

    protected FinancialEntry() { }
}
