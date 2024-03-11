using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain;

namespace StockManager.Infrastructure.Configurations
{
    internal sealed class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.Property(s => s.Id)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}
