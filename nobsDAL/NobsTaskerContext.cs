using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace nobsDAL;

public partial class NobsTaskerContext : DbContext
{
    public NobsTaskerContext()
    {
    }

    public NobsTaskerContext(DbContextOptions<NobsTaskerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PlannerItem> PlannerItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseSqlServer("Server=tcp:nobplanner.database.windows.net,1433;Database=NoBsPlannerDb;Trusted_Connection=False;User ID=nobadmin;Password=N0bplanner;");
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlannerItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
