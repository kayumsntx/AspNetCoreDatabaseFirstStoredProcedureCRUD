using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDatabaseFirstStoredProcedureCRUD.Models;

public partial class SpcoreDbContext : DbContext
{
    public SpcoreDbContext()
    {
    }

    public SpcoreDbContext(DbContextOptions<SpcoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillModule> SkillModules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=spcoreDB; Trusted_Connection=True; TrustServerCertificate=True; Encrypt=False; MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11662A70DD");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.JoinDate).HasColumnType("datetime");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SkillBudget).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Skill).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("FK__Employee__SkillI__38996AB5");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skill__DFA09187D820A0F8");

            entity.ToTable("Skill");

            entity.Property(e => e.SkillName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SkillModule>(entity =>
        {
            entity.HasKey(e => e.SkillModuleId).HasName("PK__SkillMod__CDCC035FB5613FF0");

            entity.ToTable("SkillModule");

            entity.Property(e => e.ModuleName)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.SkillModules)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__SkillModu__Emplo__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
