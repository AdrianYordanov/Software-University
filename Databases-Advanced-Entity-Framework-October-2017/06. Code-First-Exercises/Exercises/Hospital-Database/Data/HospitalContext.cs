namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Visitation> Visitations
        {
            get;
            set;
        }

        public DbSet<Diagnose> Diagnoses
        {
            get;
            set;
        }

        public DbSet<Patient> Patients
        {
            get;
            set;
        }

        public DbSet<Medicament> Medicaments
        {
            get;
            set;
        }

        public DbSet<PatientMedicament> PatientsMedicaments
        {
            get;
            set;
        }

        public DbSet<Doctor> Doctors
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient)
                .HasForeignKey(v => v.PatientId);
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId);
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(
                    pm => new
                    {
                        pm.PatientId,
                        pm.MedicamentId
                    });
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Visitations)
                .WithOne(v => v.Doctor)
                .HasForeignKey(v => v.DoctorId);
        }
    }
}