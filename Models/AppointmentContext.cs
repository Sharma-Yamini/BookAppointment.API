using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookAppointment.API.Models
{
    public partial class AppointmentContext : DbContext
    {
        public AppointmentContext()
        {
        }

        public AppointmentContext(DbContextOptions<AppointmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<DoctorDetail> DoctorDetails { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=MANNKISHAKTI;Database=Appointment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.UserId, "UQ__Admin__1788CC4DC36B55F5")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoctorDetail>(entity =>
            {
                entity.HasIndex(e => e.MobileNo, "Unq_DoctorDetails_MobileNo")
                    .IsUnique();

                entity.Property(e => e.Availability).HasColumnType("date");

                entity.Property(e => e.Experience)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MobileNO")
                    .IsFixedLength(true);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeCode)
                    .HasName("PK_EmployeeDetails_Id");

                entity.HasIndex(e => e.UserId, "UQ__Employee__1788CC4D26E020D2")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Employee__A9D105340A2214D7")
                    .IsUnique();

                entity.HasIndex(e => e.MobileNo, "Unq_EmployeeDetails_MobileNo")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MobileNO")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
