using Domain.RecurringEntries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class RecurringEntryOccurrenceConfiguration : IEntityTypeConfiguration<RecurringEntryOccurrence>
{
    public void Configure(EntityTypeBuilder<RecurringEntryOccurrence> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.RecurringEntry)
            .WithMany(x => x.Occurrences)
            .HasForeignKey(x => x.RecurringEntryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.FinancialEntry)
            .WithOne()
            .HasForeignKey<RecurringEntryOccurrence>(x => x.FinancialEntryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
