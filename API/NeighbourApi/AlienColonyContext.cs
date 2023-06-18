using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeighbourApi;

public partial class AlienColonyContext : DbContext
{
    public AlienColonyContext()
    {
    }

    public AlienColonyContext(DbContextOptions<AlienColonyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colony> Colonies { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Population> Populations { get; set; }

    public virtual DbSet<TypeofCompany> TypeofCompanies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=pontus;password=nisseHasse#34;database=AlienColony", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.12-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Colony>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Colony");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");
            entity.Property(e => e.ColonyName).HasMaxLength(255);
            entity.Property(e => e.EnergyConsumption).HasColumnType("bigint(20)");
            entity.Property(e => e.FoodConsumption).HasColumnType("bigint(20)");
            entity.Property(e => e.Income).HasColumnType("bigint(20)");
            entity.Property(e => e.MaxPopulation).HasColumnType("bigint(20)");
            entity.Property(e => e.Outcome).HasColumnType("bigint(20)");
            entity.Property(e => e.WaterConsumption).HasColumnType("bigint(20)");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ColonyId, "ColonyId");

            entity.HasIndex(e => e.TypeofCompany, "TypeofCompany");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ColonyId).HasColumnType("bigint(20)");
            entity.Property(e => e.Income).HasColumnType("bigint(20) unsigned");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NumbEmployees).HasColumnType("int(10) unsigned");
            entity.Property(e => e.Outcome).HasColumnType("bigint(20) unsigned");
            entity.Property(e => e.TypeofCompany).HasColumnType("int(10) unsigned");

            entity.HasOne(d => d.Colony).WithMany(p => p.Companies)
                .HasForeignKey(d => d.ColonyId)
                .HasConstraintName("Companies_ibfk_1");

            entity.HasOne(d => d.TypeofCompanyNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.TypeofCompany)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Companies_ibfk_2");
        });

        modelBuilder.Entity<Population>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Population");

            entity.HasIndex(e => e.ColonyId, "ColonyId");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");
            entity.Property(e => e.Age).HasColumnType("int(11)");
            entity.Property(e => e.ColonyId).HasColumnType("bigint(20)");
            entity.Property(e => e.Income).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Occupation).HasMaxLength(255);

            entity.HasOne(d => d.Colony).WithMany(p => p.Populations)
                .HasForeignKey(d => d.ColonyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Population_ibfk_1");
        });

        modelBuilder.Entity<TypeofCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TypeofCompany");

            entity.Property(e => e.Id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.Type).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
