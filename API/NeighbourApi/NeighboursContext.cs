using Microsoft.EntityFrameworkCore;
using NeighbourApi.Models;

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
        => optionsBuilder.UseSqlServer("Name=defaultConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Apartmen__3214EC07CEBE8879");

            entity.Property(e => e.BuildingLetter)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.Building).WithMany(p => p.Apartments)
                .HasForeignKey(d => new { d.BuildingNumber, d.BuildingLetter })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Apartments__5441852A");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => new { e.BuildingNumber, e.BuildingLetter }).HasName("PK__Building__97436DCCE9BCFAC8");

            entity.Property(e => e.BuildingLetter)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.LastTimeServiced).HasColumnType("datetime");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tenant__3214EC07B4E5E0B1");

            entity.ToTable("Tenant");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Apartment).WithMany(p => p.Tenants)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("FK__Tenant__Apartmen__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
