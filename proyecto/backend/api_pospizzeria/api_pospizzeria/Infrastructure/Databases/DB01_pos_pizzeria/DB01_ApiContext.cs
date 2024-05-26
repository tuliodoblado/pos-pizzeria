using System;
using System.Collections.Generic;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;

public partial class DB01_ApiContext : DbContext
{
    public DB01_ApiContext(DbContextOptions<DB01_ApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cli1> Cli1 { get; set; }

    public virtual DbSet<Ocli> Ocli { get; set; }

    public virtual DbSet<Odr1> Odr1 { get; set; }

    public virtual DbSet<Oinv> Oinv { get; set; }

    public virtual DbSet<Oodr> Oodr { get; set; }

    public virtual DbSet<Opct> Opct { get; set; }

    public virtual DbSet<Opmt> Opmt { get; set; }

    public virtual DbSet<Oprt> Oprt { get; set; }

    public virtual DbSet<Orol> Orol { get; set; }

    public virtual DbSet<Ousr> Ousr { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Cli1Config());
        modelBuilder.ApplyConfiguration(new OcliConfig());
        modelBuilder.ApplyConfiguration(new Odr1Config());
        modelBuilder.ApplyConfiguration(new OinvConfig());
        modelBuilder.ApplyConfiguration(new OodrConfig());
        modelBuilder.ApplyConfiguration(new OpctConfig());
        modelBuilder.ApplyConfiguration(new OpmtConfig());
        modelBuilder.ApplyConfiguration(new OprtConfig());
        modelBuilder.ApplyConfiguration(new OusrConfig());
        modelBuilder.ApplyConfiguration(new OrolConfig());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
