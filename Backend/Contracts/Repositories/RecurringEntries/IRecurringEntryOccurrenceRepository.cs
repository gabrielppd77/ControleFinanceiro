using Domain.RecurringEntries;

namespace Contracts.Repositories.RecurringEntries;

public interface IRecurringEntryOccurrenceRepository
{
    Task<bool> ExistsForMonth(Guid recurringEntryId, int year, int month);
    Task Add(RecurringEntryOccurrence occurrence);
}
