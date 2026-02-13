using Domain.FinancialEntries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class FinancialEntryConfiguration : IEntityTypeConfiguration<FinancialEntry>
{
    public void Configure(EntityTypeBuilder<FinancialEntry> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey(x => x.TypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Classification)
            .WithMany()
            .HasForeignKey(x => x.ClassificationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}