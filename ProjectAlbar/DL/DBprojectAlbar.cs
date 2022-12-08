using System;
using ProjectAlbar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Entity;

#nullable disable

namespace ProjectAlbar.DL
{
    public partial class DBprojectAlbar : Microsoft.EntityFrameworkCore.DbContext
    {
        public DBprojectAlbar()
        {
        }

        public DBprojectAlbar(DbContextOptions<DBprojectAlbar> options)
            : base(options)
        {
        }


        public virtual Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public virtual Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-49VMUKQ;Database=ProjectAlbar;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Category).HasColumnName("Category");

                entity.Property(e => e.UnitsInStock).HasColumnName("unitsInStock");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("productName");
            });

            

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");
                entity.Property(e => e.LastLogIn).HasColumnName("lastLogIn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
