using Domain.FinancialTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class FinancialTypeConfiguration : IEntityTypeConfiguration<FinancialType>
{
    public void Configure(EntityTypeBuilder<FinancialType> builder)
    {
        builder.HasKey(x => x.Id);
    }
}