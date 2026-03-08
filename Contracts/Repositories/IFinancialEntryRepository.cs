
using Domain.FinancialEntries;

namespace Contracts.Repositories;

public interface IFinancialEntryRepository
{
    Task<List<FinancialEntry>> GetAllToList();
    Task<List<FinancialEntry>> GetEntriesOfMonth(DateTime date);
}
