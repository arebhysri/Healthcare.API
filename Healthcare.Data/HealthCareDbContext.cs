using Healthcare.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Data
{
    public class HealthCareDbContext(DbContextOptions<HealthCareDbContext> options) : DbContext(options)
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<TelehealthSession> TelehealthSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.Address).IsRequired();
            });
            modelBuilder.Entity<Doctor>(entity => {
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Specialization).IsRequired();
                entity.Property(e => e.LicenseNumber).IsRequired();
                entity.Property(e => e.ExperienceYear).IsRequired();
                entity.Property(e => e.AvailabilitySlot).IsRequired();
            });
            modelBuilder.Entity<MedicalRecord>(entity => {
                entity.Property(e => e.PatientId).IsRequired();
                entity.Property(e => e.DoctorId).IsRequired();
                entity.Property(e => e.PatientId).IsRequired();
            }); 
            modelBuilder.Entity<Appointment>(entity => {
                entity.Property(e => e.PatientId).IsRequired();
                entity.Property(e => e.DoctorId).IsRequired();
                entity.Property(e => e.AppoinmentDate).IsRequired();
            }); 
            modelBuilder.Entity<TelehealthSession>(entity => {
                entity.Property(e => e.AppointmentId).IsRequired();
            });
            modelBuilder.Entity<Appointment>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(a => a.PatientId);
            modelBuilder.Entity<Appointment>()
                .HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(a => a.DoctorId);
        }
    }
}
