﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockManager.Infrastructure.DbContexts;

#nullable disable

namespace StockManager.Infrastructure.Migrations
{
    [DbContext(typeof(StockManagerDbContext))]
    partial class StockManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockManager.Domain.Broker", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Brokers");
                });

            modelBuilder.Entity("StockManager.Domain.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TickerSymbol")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockManager.Domain.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("BrokerId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NumberOfShares")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("StockId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("BrokerId");

                    b.HasIndex("StockId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("StockManager.Domain.Transaction", b =>
                {
                    b.HasOne("StockManager.Domain.Broker", "Broker")
                        .WithMany()
                        .HasForeignKey("BrokerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockManager.Domain.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Broker");

                    b.Navigation("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}
