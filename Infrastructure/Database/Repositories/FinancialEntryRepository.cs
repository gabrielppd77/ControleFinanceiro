using System.Globalization;
using Contracts.Repositories.FinancialEntries;
using Contracts.Repositories.FinancialEntries.Dtos;
using Domain.FinancialEntries;
using Infrastructure.Database.Context;
using Infrastructure.Database.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class FinancialEntryRepository : BaseRepository<FinancialEntry>, IFinancialEntryRepository
{
    public FinancialEntryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<FinancialEntry>> GetAllToList()
    {
        return await _dbSet.Include(x => x.Type).Include(x => x.Classification).ToListAsync();
    }

    public async Task<List<FinancialEntry>> GetEntriesOfMonth(DateTime date)
    {
        return await _dbSet
            .Where(x => x.Date.Month == date.Month)
            .Where(x => x.Date.Year == date.Year)
            .ToListAsync();
    }

    public async Task<List<ChartDataOfYearDto>> GetChartDataOfYear(DateTime date)
    {
        var year = date.Year;

        var result = await _dbSet
            .Where(x => x.Date.Year == year)
            .GroupBy(x => new
            {
                Month = x.Date.Month,
                Classification = x.Classification.Name
            })
            .Select(g => new
            {
                g.Key.Month,
                Label = g.Key.Classification,
                Value = g.Sum(x => x.Amount)
            })
            .OrderBy(x => x.Month)
            .ToListAsync();

        return result
            .Select(x => new ChartDataOfYearDto(
                CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat.GetAbbreviatedMonthName(x.Month), 
                x.Label, 
                x.Value))
            .ToList();
    }
}
