using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ServiceStore.Models;

namespace ServiceStore.Data
{
    public partial class ServiceStoreContext : DbContext
    {
        public ServiceStoreContext()
        {
        }

        public ServiceStoreContext(DbContextOptions<ServiceStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(100)
                    .HasColumnName("invoice_code");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(25)
                    .HasColumnName("payment_status");

                entity.Property(e => e.ProvinceId).HasColumnName("province_id");

                entity.Property(e => e.ShippingAddress)
                    .HasColumnType("text")
                    .HasColumnName("shipping_address");

                entity.Property(e => e.ShippingCost)
                    .HasMaxLength(50)
                    .HasColumnName("shipping_cost");

                entity.Property(e => e.TotalPrice)
                    .HasMaxLength(100)
                    .HasColumnName("total_price");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountProductsPrice).HasColumnName("amount_products_price");

                entity.Property(e => e.CityId)
                    .HasMaxLength(50)
                    .HasColumnName("city_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(100)
                    .HasColumnName("invoice_code");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(100)
                    .HasColumnName("payment_status");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(50)
                    .HasColumnName("province_id");

                entity.Property(e => e.ShippingAddress)
                    .HasMaxLength(100)
                    .HasColumnName("shipping_address");

                entity.Property(e => e.ShippingCost).HasColumnName("shipping_cost");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
