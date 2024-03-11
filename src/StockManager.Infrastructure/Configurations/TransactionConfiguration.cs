using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain;

namespace StockManager.Infrastructure.Configurations
{
    internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.Id)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasOne(t => t.Broker)
                .WithMany()
                .HasForeignKey(t => t.BrokerId);

            builder.HasOne(t => t.Stock)
                .WithMany()
                .HasForeignKey(t => t.StockId);
        }
    }
}