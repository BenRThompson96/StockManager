using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain;

namespace StockManager.Infrastructure.Configurations
{
    internal sealed class BrokerConfiguration : IEntityTypeConfiguration<Broker>
    {
        public void Configure(EntityTypeBuilder<Broker> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}