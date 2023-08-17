using System;
using System.Collections.Generic;
using JWTAuthentication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Data.Settings;

public partial class EmsContext : DbContext
{
    public EmsContext()
    {
    }

    public EmsContext(DbContextOptions<EmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<UserDetails> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE488D59983EC");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Email, "UQ__Admin__A9D10534A0C5FED1").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasColumnName("Created_At");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_AT");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ExpDays)
                .HasDefaultValueSql("((7))")
                .HasColumnName("Exp_Days");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordUpdatedAt)
                .HasColumnType("date")
                .HasColumnName("Password_Updated_At");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_At");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11F0241FCC");

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D105345750122A").IsUnique();

            entity.Property(e => e.Attemps).HasDefaultValueSql("((0))");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Created_At");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_AT");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ExpDays)
                .HasDefaultValueSql("((7))")
                .HasColumnName("Exp_days");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordUpdatedAt)
                .HasColumnType("date")
                .HasColumnName("Password_Updated_At");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            entity.Property(e => e.TotalAttemps).HasColumnName("Total_Attemps");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_At");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserDetails>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserInfo");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
