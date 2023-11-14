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

    public virtual DbSet<Cousre> Cousres { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserAccount> Useraccounts { get; set; }

    public virtual DbSet<Usercousre> Usercousres { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##QR")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Certificaton>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008507");

            entity.ToTable("CERTIFICATON");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CertificatonUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CERTIFICATON_URL");
            entity.Property(e => e.DateofIssuance)
                .HasColumnType("DATE")
                .HasColumnName("DATEOF_ISSUANCE");
            entity.Property(e => e.UsercousreId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERCOUSRE_ID");

            entity.HasOne(d => d.Usercousre).WithMany(p => p.Certificatons)
                .HasForeignKey(d => d.UsercousreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("USERCOUSRE_FK");
        });

        modelBuilder.Entity<Cousre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008501");

            entity.ToTable("COUSRE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Cousrename)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("COUSRENAME");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Instructor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("INSTRUCTOR");
            entity.Property(e => e.Startdate)
                .HasColumnType("DATE")
                .HasColumnName("STARTDATE");
            entity.Property(e => e.Time)
                .HasColumnType("DATE")
                .HasColumnName("TIME");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008496");

            entity.ToTable("ROLE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008498");

            entity.ToTable("USERACCOUNT");

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
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("DATE")
                .HasColumnName("DATEOFBIRTH");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Firstname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.ImagUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("IMAG_URL");
            entity.Property(e => e.Lastname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
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

            entity.HasOne(d => d.Role).WithMany(p => p.Useraccounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ROLE_FK");
        });

        modelBuilder.Entity<Usercousre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008503");

            entity.ToTable("USERCOUSRE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CousreId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COUSRE_ID");
            entity.Property(e => e.Mark)
                .HasColumnType("NUMBER")
                .HasColumnName("MARK");
            entity.Property(e => e.Stuts)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STUTS");
            entity.Property(e => e.UseraccountId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERACCOUNT_ID");

            entity.HasOne(d => d.Cousre).WithMany(p => p.Usercousres)
                .HasForeignKey(d => d.CousreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("COUSRE_FK");

            entity.HasOne(d => d.Useraccount).WithMany(p => p.Usercousres)
                .HasForeignKey(d => d.UseraccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("USERACCOUNT_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
