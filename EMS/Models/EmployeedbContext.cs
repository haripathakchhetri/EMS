﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMS.Models;

public partial class EmployeedbContext : DbContext
{
    public EmployeedbContext()
    {
    }

    public EmployeedbContext(DbContextOptions<EmployeedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartmentTable> DepartmentTables { get; set; }

    public virtual DbSet<DesignationTable> DesignationTables { get; set; }

    public virtual DbSet<EmployeeTable> EmployeeTables { get; set; }

    public virtual DbSet<LeaveTable> LeaveTables { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    public virtual DbSet<VacancyTable> VacancyTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentTable>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__departme__B2079BED41C46FF2");

            entity.ToTable("departmentTable");

            entity.HasIndex(e => e.DepartmentName, "UQ__departme__D949CC348098BAC4").IsUnique();

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
        });

        modelBuilder.Entity<DesignationTable>(entity =>
        {
            entity.HasKey(e => e.DesignationId).HasName("PK__designat__BABD60DEC632EA63");

            entity.ToTable("designationTable");

            entity.HasIndex(e => e.DesignationName, "UQ__designat__372CDC238D635060").IsUnique();

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DesignationName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeTable>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__7AD04F11CC883190");

            entity.ToTable("employeeTable");

            entity.HasIndex(e => e.Email, "UQ__employee__A9D10534E4A03542").IsUnique();

            entity.HasIndex(e => e.Contact, "UQ__employee__F7C04665DBC98DD4").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("numeric(18, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeTables)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__employeeT__Depar__2F10007B");

            entity.HasOne(d => d.Designation).WithMany(p => p.EmployeeTables)
                .HasForeignKey(d => d.DesignationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__employeeT__Desig__300424B4");
        });

        modelBuilder.Entity<LeaveTable>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__leaveTab__796DB959A10F4FB6");

            entity.ToTable("leaveTable");

            entity.Property(e => e.LeaveDate).HasColumnType("date");
            entity.Property(e => e.LeaveStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Reason).IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.LeaveTables)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__leaveTabl__Emplo__32E0915F");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__userTabl__1788CC4C5B258ADA");

            entity.ToTable("userTable");

            entity.HasIndex(e => e.UserName, "UQ__userTabl__C9F284565A5D6594").IsUnique();

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VacancyTable>(entity =>
        {
            entity.HasKey(e => e.VacancyId).HasName("PK__vacancyT__6456763F2465464A");

            entity.ToTable("vacancyTable");

            entity.Property(e => e.VacancyFrom).HasColumnType("date");
            entity.Property(e => e.VacancyTo).HasColumnType("date");

            entity.HasOne(d => d.Department).WithMany(p => p.VacancyTables)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__vacancyTa__Depar__35BCFE0A");

            entity.HasOne(d => d.Designation).WithMany(p => p.VacancyTables)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK__vacancyTa__Desig__36B12243");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
