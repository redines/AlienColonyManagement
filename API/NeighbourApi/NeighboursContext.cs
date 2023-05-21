using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeighbourApi;

public partial class NeighboursContext : DbContext
{
    public NeighboursContext()
    {
    }

    public NeighboursContext(DbContextOptions<NeighboursContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apartment> Apartments { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:MariaDbConnectionString", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.13-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Apartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => new { e.BuildingNumber, e.BuildingLetter }, "BuildingNumber");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");
            entity.Property(e => e.ApartmentNumber).HasColumnType("int(11)");
            entity.Property(e => e.BuildingLetter).HasMaxLength(5);
            entity.Property(e => e.BuildingNumber).HasColumnType("bigint(20)");
            entity.Property(e => e.LivingSize).HasColumnType("int(11)");
            entity.Property(e => e.MonthlyRent).HasColumnType("bigint(20)");
            entity.Property(e => e.NumberOfRooms).HasColumnType("int(20)");
            entity.Property(e => e.NumberofTenants).HasColumnType("int(20)");

            entity.HasOne(d => d.Building).WithMany(p => p.Apartments)
                .HasForeignKey(d => new { d.BuildingNumber, d.BuildingLetter })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("apartments_ibfk_1");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => new { e.BuildingNumber, e.BuildingLetter })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.BuildingNumber).HasColumnType("bigint(20)");
            entity.Property(e => e.BuildingLetter).HasMaxLength(5);
            entity.Property(e => e.LastTimeServiced).HasColumnType("datetime");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Tenant");

            entity.HasIndex(e => e.ApartmentId, "ApartmentId");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");
            entity.Property(e => e.Age).HasColumnType("int(11)");
            entity.Property(e => e.ApartmentId).HasColumnType("bigint(20)");
            entity.Property(e => e.IncomeMonth).HasColumnType("bigint(20)");
            entity.Property(e => e.IncomeYear).HasColumnType("bigint(20)");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProfilePicture).HasColumnType("blob");

            entity.HasOne(d => d.Apartment).WithMany(p => p.Tenants)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("tenant_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
