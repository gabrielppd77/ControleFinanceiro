using Contracts.Repositories;
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
}
