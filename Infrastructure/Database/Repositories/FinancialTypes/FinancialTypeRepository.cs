using Contracts.Repositories.FinancialTypes;
using Domain.FinancialTypes;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.FinancialTypes;


public class FinancialTypeRepository : IFinancialTypeRepository
{
    private ApplicationDbContext _context;

    public FinancialTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(FinancialType financialType)
    {
        await _context.FinancialTypes.AddAsync(financialType);
    }

    public async Task<List<FinancialType>> GetAll(Guid userId)
    {
        return await _context.FinancialTypes
            .Where(x => x.UserId == userId)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<FinancialType?> GetById(Guid id)
    {
        return await _context.FinancialTypes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Remove(FinancialType financialType)
    {
        _context.FinancialTypes.Remove(financialType);
    }
}
