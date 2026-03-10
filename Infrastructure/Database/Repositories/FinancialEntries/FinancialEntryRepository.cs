using System.Globalization;
using Contracts.Repositories.FinancialEntries;
using Contracts.Repositories.FinancialEntries.Dtos;
using Domain.FinancialEntries;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.FinancialEntries;

public class FinancialEntryRepository : IFinancialEntryRepository
{
    private ApplicationDbContext _context;

    public FinancialEntryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<FinancialEntry>> GetAll(Guid userId)
    {
        return await _context.FinancialEntries
            .Where(x => x.UserId == userId)
            .Include(x => x.Type)
            .Include(x => x.Classification)
            .ToListAsync();
    }

    public async Task<List<FinancialEntry>> GetEntriesOfMonth(DateTime date, Guid userId)
    {
        return await _context.FinancialEntries
            .Where(x => x.UserId == userId)
            .Where(x => x.Date.Month == date.Month)
            .Where(x => x.Date.Year == date.Year)
            .ToListAsync();
    }

    public async Task<List<ChartDataOfYearDto>> GetChartDataOfYear(DateTime date, Guid userId)
    {
        var year = date.Year;

        var result = await _context.FinancialEntries
            .Where(x => x.UserId == userId)
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

    public async Task Add(FinancialEntry financialEntry)
    {
        await _context.FinancialEntries.AddAsync(financialEntry);
    }

    public async Task<FinancialEntry?> GetById(Guid id)
    {
        return await _context.FinancialEntries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Remove(FinancialEntry financialEntry)
    {
        _context.FinancialEntries.Remove(financialEntry);
    }
}
