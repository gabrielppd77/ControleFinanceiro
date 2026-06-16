using Domain.Base;
using Domain.FinancialEntries;

namespace Domain.RecurringEntries;

public class RecurringEntryOccurrence : Entity
{
    public Guid RecurringEntryId { get; protected set; }
    public RecurringEntry RecurringEntry { get; protected set; }
    public Guid FinancialEntryId { get; protected set; }
    public FinancialEntry FinancialEntry { get; protected set; }
    public DateOnly OccurrenceDate { get; protected set; }

    protected RecurringEntryOccurrence() { }

    public RecurringEntryOccurrence(Guid recurringEntryId, Guid financialEntryId, DateOnly occurrenceDate)
    {
        RecurringEntryId = recurringEntryId;
        FinancialEntryId = financialEntryId;
        OccurrenceDate = occurrenceDate;
    }
}
