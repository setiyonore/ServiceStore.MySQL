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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CityId)
                    .HasColumnType("int(3)")
                    .HasColumnName("city_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(100)
                    .HasColumnName("invoice_code");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(25)
                    .HasColumnName("payment_status");

                entity.Property(e => e.ProvinceId)
                    .HasColumnType("int(3)")
                    .HasColumnName("province_id");

                entity.Property(e => e.ShippingAddress)
                    .HasColumnType("text")
                    .HasColumnName("shipping_address");

                entity.Property(e => e.ShippingCost)
                    .HasMaxLength(50)
                    .HasColumnName("shipping_cost");

                entity.Property(e => e.TotalPrice)
                    .HasMaxLength(100)
                    .HasColumnName("total_price");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
