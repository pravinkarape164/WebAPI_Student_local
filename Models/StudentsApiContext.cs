using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Student.Models;

public partial class StudentsApiContext : DbContext
{
    public StudentsApiContext()
    {
    }

    public StudentsApiContext(DbContextOptions<StudentsApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            // Define the primary key for the Student entity
            entity.HasKey(e => e.Id);

            // Configure the properties
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd(); // Optional, EF Core will automatically set this for int primary keys

            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.StudentGender)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
