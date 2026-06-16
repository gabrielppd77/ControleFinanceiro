using Contracts.Repositories.FinancialAccounts;
using Domain.FinancialAccounts;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.FinancialAccounts;

public class FinancialAccountRepository : IFinancialAccountRepository
{
    private ApplicationDbContext _context;

    public FinancialAccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(FinancialAccount financialAccount)
    {
        await _context.FinancialAccounts.AddAsync(financialAccount);
    }

    public async Task<List<FinancialAccount>> GetAll(Guid userId)
    {
        return await _context.FinancialAccounts
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<FinancialAccount?> GetById(Guid id)
    {
        return await _context.FinancialAccounts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Remove(FinancialAccount financialAccount)
    {
        _context.FinancialAccounts.Remove(financialAccount);
    }
}
