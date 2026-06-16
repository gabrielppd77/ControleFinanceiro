using Contracts.Repositories;
using Domain.Base;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveChanges()
    {
        var entries = _context.ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            if (entry.Entity is Entity entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.CreateFieldCreatedAt();
                }

                if (entry.State == EntityState.Modified)
                {
                    entity.UpdateFieldUpdatedAt();
                }
            }
        }

        await _context.SaveChangesAsync();
    }
}
