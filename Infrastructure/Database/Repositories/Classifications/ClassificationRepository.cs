using Contracts.Repositories.Classifications;
using Domain.Classifications;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Classifications;

public class ClassificationRepository : IClassificationRepository
{
    private ApplicationDbContext _context;

    public ClassificationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Classification classification)
    {
        await _context.Classifications.AddAsync(classification);
    }

    public async Task<List<Classification>> GetAll()
    {
        return await _context.Classifications.OrderBy(x => x.Name).ToListAsync();
    }

    public async Task<Classification?> GetById(Guid id)
    {
        return await _context.Classifications.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Remove(Classification classification)
    {
        _context.Classifications.Remove(classification);
    }
}
