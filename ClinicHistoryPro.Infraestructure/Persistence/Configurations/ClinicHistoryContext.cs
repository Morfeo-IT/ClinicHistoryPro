using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClinicHistoryPro.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace ClinicHistoryPro.Infraestructure.Persistence.Configurations
{
    public partial class ClinicHistoryContext : DbContext
    {
        public ClinicHistoryContext()
        {
        }

        public ClinicHistoryContext(DbContextOptions<ClinicHistoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Consultation> Consultations { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<DiagnosisCie> DiagnosisCies { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<FhirResource> FhirResources { get; set; } = null!;
        public virtual DbSet<Form> Forms { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<HistoryClinic> HistoryClinics { get; set; } = null!;
        public virtual DbSet<Hl7Message> Hl7Messages { get; set; } = null!;
        public virtual DbSet<Input> Inputs { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:ConnectionStringLocal"] ?? "")
                .EnableSensitiveDataLogging(true); // En producción cambiar a false
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("Administrator");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.Name).HasMaxLength(125);

                entity.Property(e => e.ShortName).HasMaxLength(125);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cities__state_id__778AC167");
            });

            modelBuilder.Entity<Consultation>(entity =>
            {
                entity.ToTable("Consultation");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.Diagnosis).HasMaxLength(500);

                entity.Property(e => e.ReasonConsultation).HasMaxLength(500);

                entity.Property(e => e.Treatment).HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");

                entity.HasOne(d => d.HistoryClinic)
                    .WithMany(p => p.Consultations)
                    .HasForeignKey(d => d.HistoryClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consultat__Histo__4316F928");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            modelBuilder.Entity<DiagnosisCie>(entity =>
            {
                entity.ToTable("DiagnosisCie");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.Description).HasMaxLength(125);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            modelBuilder.Entity<FhirResource>(entity =>
            {
                entity.ToTable("FHIR_Resources");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.ResourceType).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("Form");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_at");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            modelBuilder.Entity<HistoryClinic>(entity =>
            {
                entity.ToTable("HistoryClinic");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.HistoryClinics)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HistoryCl__Patie__403A8C7D");
            });

            modelBuilder.Entity<Hl7Message>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK__HL7_Mess__C87C037C8EF3262E");

                entity.ToTable("HL7_Messages");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.MessageType).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            modelBuilder.Entity<Input>(entity =>
            {
                entity.ToTable("Input");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_at");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.Concentration).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.GenericName).HasMaxLength(100);

                entity.Property(e => e.Presentation).HasMaxLength(100);

                entity.Property(e => e.Tradename).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ParentMenuItemId).HasColumnName("ParentMenuItemID");

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");

                entity.Property(e => e.Url).HasMaxLength(255);

                entity.HasOne(d => d.ParentMenuItem)
                    .WithMany(p => p.InverseParentMenuItem)
                    .HasForeignKey(d => d.ParentMenuItemId)
                    .HasConstraintName("FK_MenuItems_ParentMenuItem");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DateBirth).HasColumnType("date");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.DocumentNumber).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__Documen__3D5E1FD2");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__GenderI__3C69FB99");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_at");

                entity.Property(e => e.Dose).HasMaxLength(50);

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.Frequency).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");

                entity.HasOne(d => d.Consultation)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.ConsultationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__Consu__47DBAE45");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__Medic__48CFD27E");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
