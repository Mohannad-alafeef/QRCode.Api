using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QRCode.Api.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certificaton> Certificatons { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserCourse> UserCourses { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##QR")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Certificaton>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008521");

            entity.ToTable("CERTIFICATON");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CertificatonUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CERTIFICATON_URL");
            entity.Property(e => e.DateOfIssuance)
                .HasColumnType("DATE")
                .HasColumnName("DATE_OF_ISSUANCE");
            entity.Property(e => e.Token)
                .HasMaxLength(200)
                .HasColumnName("TOKEN");
            entity.Property(e => e.UserCourseId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_COURSE_ID");

            entity.HasOne(d => d.UserCourse).WithMany(p => p.Certificatons)
                .HasForeignKey(d => d.UserCourseId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_CERTIFICATON_USERCOURSE");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008515");

            entity.ToTable("COURSE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("COURSE_NAME");
            entity.Property(e => e.EndDate)
                .HasColumnType("DATE")
                .HasColumnName("END_DATE");
            entity.Property(e => e.ImagUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("IMAG_URL");
            entity.Property(e => e.Instructor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("INSTRUCTOR");
            entity.Property(e => e.StartDate)
                .HasColumnType("DATE")
                .HasColumnName("START_DATE");
            entity.Property(e => e.Time)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TIME");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008510");

            entity.ToTable("ROLE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ROLE_NAME");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008512");

            entity.ToTable("USER_ACCOUNT");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.CvUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CV_URL");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("DATE")
                .HasColumnName("DATE_OF_BIRTH");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.ImagUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("IMAG_URL");
            entity.Property(e => e.LastName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.RoleId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLE_ID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_USERCOUSRE_ROLE");
        });

        modelBuilder.Entity<UserCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008517");

            entity.ToTable("USER_COURSE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CourseId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.Mark)
                .HasColumnType("NUMBER")
                .HasColumnName("MARK");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UserAccountId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_ACCOUNT_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.UserCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_USERCOURSE_COURSE");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.UserCourses)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_USERCOURSE_USERACCOUNT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
