using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication3_Cookies.Models;

namespace WebApplication3_Cookies.DB;

public partial class User503Context : DbContext
{
    public User503Context()
    {
    }

    public User503Context(DbContextOptions<User503Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<CrossUserRequest> CrossUserRequests { get; set; }

    public virtual DbSet<DarkList> DarkLists { get; set; }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Reason> Reasons { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Subdivision> Subdivisions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<VisitPorpose> VisitPorposes { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=192.168.200.35;database=user_50_3;user=user50;password=26643;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_100_CI_AI_KS_SC_UTF8");

        modelBuilder.Entity<Access>(entity =>
        {
            entity.ToTable("Access");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<CrossUserRequest>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdRequest });

            entity.ToTable("CrossUserRequest");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.IdRequest).HasColumnName("ID_Request");

            entity.HasOne(d => d.IdRequestNavigation).WithMany(p => p.CrossUserRequests)
                .HasForeignKey(d => d.IdRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CrossUserRequest_Request");

            entity.HasOne(d => d.IdRequest1).WithMany(p => p.CrossUserRequests)
                .HasForeignKey(d => d.IdRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CrossUserRequest_User");
        });

        modelBuilder.Entity<DarkList>(entity =>
        {
            entity.ToTable("DarkList");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.DarkLists)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DarkList_User");
        });

        modelBuilder.Entity<Departament>(entity =>
        {
            entity.ToTable("Departament");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Reason>(entity =>
        {
            entity.ToTable("Reason");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("Request");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdReason).HasColumnName("ID_Reason");
            entity.Property(e => e.IdStatus).HasColumnName("ID_Status");
            entity.Property(e => e.IdVisitPorose).HasColumnName("ID_VisitPorose");
            entity.Property(e => e.IdWorker).HasColumnName("ID_Worker");
            entity.Property(e => e.TimeEnd).HasColumnType("datetime");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");

            entity.HasOne(d => d.IdReasonNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdReason)
                .HasConstraintName("FK_Request_Reason");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK_Request_Status");

            entity.HasOne(d => d.IdVisitPoroseNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdVisitPorose)
                .HasConstraintName("FK_Request_VisitPorpose");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdWorker)
                .HasConstraintName("FK_Request_Worker");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Subdivision>(entity =>
        {
            entity.ToTable("Subdivision");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Fio).HasColumnName("FIO");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.ToTable("Visit");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdAccess).HasColumnName("ID_Access");
            entity.Property(e => e.IdRequest).HasColumnName("ID_Request");
            entity.Property(e => e.TimeEnd).HasColumnType("datetime");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");
            entity.Property(e => e.TimeSubdivisionStart).HasColumnType("datetime");
            entity.Property(e => e.TimeSubdivsionEnd).HasColumnType("datetime");

            entity.HasOne(d => d.IdAccessNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.IdAccess)
                .HasConstraintName("FK_Visit_Access");

            entity.HasOne(d => d.IdRequestNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.IdRequest)
                .HasConstraintName("FK_Visit_Request");
        });

        modelBuilder.Entity<VisitPorpose>(entity =>
        {
            entity.ToTable("VisitPorpose");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.ToTable("Worker");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fio).HasColumnName("FIO");
            entity.Property(e => e.IdDepartamint).HasColumnName("ID_Departamint");
            entity.Property(e => e.IdSubdivision).HasColumnName("ID_Subdivision");

            entity.HasOne(d => d.IdDepartamintNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.IdDepartamint)
                .HasConstraintName("FK_Worker_Departament");

            entity.HasOne(d => d.IdSubdivisionNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.IdSubdivision)
                .HasConstraintName("FK_Worker_Subdivision");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
