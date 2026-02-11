using Domain.Classifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
{
    public void Configure(EntityTypeBuilder<Classification> builder)
    {
        builder.HasKey(x => x.Id);
    }
}