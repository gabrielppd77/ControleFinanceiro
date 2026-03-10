using Contracts.Repositories.FinancialEntries.Dtos;
using Domain.FinancialEntries;

namespace Contracts.Repositories.FinancialEntries;

public interface IFinancialEntryRepository
{
    Task<List<FinancialEntry>> GetAll(Guid userId);
    Task<List<FinancialEntry>> GetEntriesOfMonth(DateTime date, Guid userId);
    Task<List<ChartDataOfYearDto>> GetChartDataOfYear(DateTime date, Guid userId);
    Task Add(FinancialEntry financialEntry);
    Task<FinancialEntry?> GetById(Guid id);
    void Remove(FinancialEntry financialEntry);
}
