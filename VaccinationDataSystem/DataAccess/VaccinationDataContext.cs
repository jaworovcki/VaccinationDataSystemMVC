using Microsoft.EntityFrameworkCore;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.DataAccess
{
	public class VaccinationDataContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientProfile> PatientProfiles { get; set; }

        public DbSet<PatientResponse> PatientResponses { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }

        public VaccinationDataContext(DbContextOptions<VaccinationDataContext> options)
            : base(options)
        {
            
        }
    }
}
