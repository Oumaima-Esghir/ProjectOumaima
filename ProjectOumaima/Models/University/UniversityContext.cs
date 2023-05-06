using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectOumaima.Models.University;

public partial class UniversityContext : DbContext
{
    public UniversityContext()
    {
    }

    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:UniversityCS");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sector__3214EC0723F4217F");

            entity.ToTable("Sector");

            entity.Property(e => e.Level).HasMaxLength(30);
            entity.Property(e => e.Nom).HasMaxLength(30);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC079B1B76ED");

            entity.ToTable("Student");

            entity.Property(e => e.Niveau).HasMaxLength(50);
            entity.Property(e => e.Nom).HasMaxLength(50);
            entity.Property(e => e.Prenom).HasMaxLength(50);

            entity.HasOne(d => d.Sector).WithMany(p => p.Students)
                .HasForeignKey(d => d.SectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
