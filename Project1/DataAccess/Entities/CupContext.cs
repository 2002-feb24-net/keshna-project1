using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class CupContext : DbContext
    {
        public CupContext()
        {
        }

        public CupContext(DbContextOptions<CupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Restaurant1> Restaurant1 { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Review1> Review1 { get; set; }
        public virtual DbSet<StoreLocation> StoreLocation { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B8A0FC650E");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Locat__02FC7413");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Produ__02084FDA");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PK__OrderDet__D3B9D30C7D7C5B14");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK__OrderDeta__Inven__0A9D95DB");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Order__09A971A2");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAFC3099067");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__05D8E0BE");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Location__06CD04F7");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6EDAFF900E6");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Restaurant1>(entity =>
            {
                entity.ToTable("Restaurant", "RR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.ReviewerName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_Review_Restaurant");
            });

            modelBuilder.Entity<Review1>(entity =>
            {
                entity.ToTable("Review", "RR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.ReviewerName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Review1)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_Review_Restaurant");
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__store_lo__771831EA34E9A617");

                entity.ToTable("store_location");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LocationAddress)
                    .IsRequired()
                    .HasColumnName("location_address")
                    .HasMaxLength(60);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasColumnName("location_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__Stores__E7FEA47761446E87");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
