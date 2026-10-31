using Microsoft.EntityFrameworkCore;
using SmartClinic.Models;

namespace SmartClinic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, FullName = "Dr. Sarah Smith", Specialization = "Cardiology", ConsultationFee = 150.00m },
                new Doctor { DoctorId = 2, FullName = "Dr. John Doe", Specialization = "Pediatrics", ConsultationFee = 100.00m },
                new Doctor { DoctorId = 3, FullName = "Dr. Emily Davis", Specialization = "Dermatology", ConsultationFee = 120.00m }
            );
        }
    }
}
