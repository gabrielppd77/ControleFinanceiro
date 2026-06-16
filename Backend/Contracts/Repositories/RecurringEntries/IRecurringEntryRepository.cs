using Domain.RecurringEntries;

namespace Contracts.Repositories.RecurringEntries;

public interface IRecurringEntryRepository
{
    Task Add(RecurringEntry recurringEntry);
    Task<List<RecurringEntry>> GetAll(Guid userId);
    Task<RecurringEntry?> GetById(Guid id);
    void Remove(RecurringEntry recurringEntry);
}
