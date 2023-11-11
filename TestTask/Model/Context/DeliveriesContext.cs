using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestTask.Model;

namespace TestTask.Model.Context
{
    public partial class DeliveriesContext : DbContext
    {
        public DeliveriesContext()
        {
        }

        public DeliveriesContext(DbContextOptions<DeliveriesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<TypeDelivery> TypeDeliveries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-M508TRG;Database=Deliveries;Trusted_Connection=True;TrustServerCertificate=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");

                entity.Property(e => e.DeliveryDateCreate).HasColumnType("date");

                entity.HasOne(d => d.Suppllier)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.SuppllierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Delivery_To_Supplier");

                entity.HasOne(d => d.TypeDelivery)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.TypeDeliveryId)
                    .HasConstraintName("FK_Delivery_TypeDelivery");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.ProductPrice).HasColumnType("money");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_To_Delivery");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierName).HasMaxLength(100);
            });

            modelBuilder.Entity<TypeDelivery>(entity =>
            {
                entity.ToTable("TypeDelivery");

                entity.Property(e => e.TypeDeliveryName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
