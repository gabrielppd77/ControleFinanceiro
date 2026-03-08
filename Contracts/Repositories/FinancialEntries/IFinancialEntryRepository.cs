using Contracts.Repositories.FinancialEntries.Dtos;
using Domain.FinancialEntries;

namespace Contracts.Repositories.FinancialEntries;

public interface IFinancialEntryRepository
{
    Task<List<FinancialEntry>> GetAllToList();
    Task<List<FinancialEntry>> GetEntriesOfMonth(DateTime date);
    Task<List<ChartDataOfYearDto>> GetChartDataOfYear(DateTime date);
}
