using System;
using System.Collections.Generic;
using MC_MZ_PF_API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MC_MZ_PF_API.Data;

public partial class McMzPfDataContext : DbContext
{
    public McMzPfDataContext()
    {
    }

    public McMzPfDataContext(DbContextOptions<McMzPfDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arte> Artes { get; set; }

    public virtual DbSet<Cultura> Culturas { get; set; }

    public virtual DbSet<Deporte> Deportes { get; set; }

    public virtual DbSet<Tecnologia> Tecnologia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MC_MZ_PF.Data");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arte>(entity =>
        {
            entity.ToTable("Arte");

            entity.Property(e => e.AsuntoArt).HasMaxLength(30);
        });

        modelBuilder.Entity<Cultura>(entity =>
        {
            entity.ToTable("Cultura");

            entity.Property(e => e.AsuntoCul).HasMaxLength(30);
        });

        modelBuilder.Entity<Deporte>(entity =>
        {
            entity.ToTable("Deporte");

            entity.Property(e => e.AsuntoDep).HasMaxLength(30);
        });

        modelBuilder.Entity<Tecnologia>(entity =>
        {
            entity.Property(e => e.AsuntoTec).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
