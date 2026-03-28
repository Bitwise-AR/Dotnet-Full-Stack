using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentMarksAPI.Models;

public partial class LpuContext : DbContext
{
    public LpuContext()
    {
    }

    public LpuContext(DbContextOptions<LpuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TblBookMaster> TblBookMasters { get; set; }

    public virtual DbSet<TblStudentMaster> TblStudentMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LPU;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07482760F0");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TblBookMaster>(entity =>
        {
            entity.HasKey(e => e.BookId);

            entity.ToTable("TblBookMaster");

            entity.Property(e => e.Title).HasMaxLength(15);
        });

        modelBuilder.Entity<TblStudentMaster>(entity =>
        {
            entity.ToTable("TblStudentMaster");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
