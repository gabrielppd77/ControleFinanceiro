using Domain.Classifications;
using Domain.FinancialTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<FinancialType> FinancialTypes { get; set; }
    public DbSet<Classification> Classifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
    }
}