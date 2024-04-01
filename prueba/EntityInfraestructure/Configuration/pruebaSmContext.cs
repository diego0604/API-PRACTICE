using System;
using System.Collections.Generic;
using GenericApplication.Interface.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBTest.InvoiceManagerDB
{
    public partial class pruebaSmContext : DbContext, IPruebaSmContext
    {
        public pruebaSmContext()
        {
        }

        public pruebaSmContext(DbContextOptions<pruebaSmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public Task BeginTransactionAsync()
        {
           return base.Database.BeginTransactionAsync();
        }

        public Task CommitTransactionAsync()
        {
            return base.Database.CommitTransactionAsync();
        }

        public Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql)
        {
            return base.Database.ExecuteSqlInterpolatedAsync(sql);
        }

        public Task<int> ExecuteSqlRawAsync(string sql)
        {
            return ExecuteSqlRawAsync(sql);
        }

        public Task RollbackTransactionAsync()
        {
            return base.Database.RollbackTransactionAsync();    
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=pruebaSm;Integrated Security=True;MultipleActiveResultSets=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__customer__D830D4779BEC0A28");

                entity.ToTable("customers");

                entity.HasIndex(e => e.Document, "C_document")
                    .IsUnique();

                entity.Property(e => e.CId)
                    .ValueGeneratedNever()
                    .HasColumnName("cId");

                entity.Property(e => e.CName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cName");

                entity.Property(e => e.Document)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("document");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(8000)
                    .HasColumnName("pwd");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("products");

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.Property(e => e.PDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("pDescription");

                entity.Property(e => e.PId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pId");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK_products_customers");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.Property(e => e.Consecutive)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("consecutive");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK_users_customers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
