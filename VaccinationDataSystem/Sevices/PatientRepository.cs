using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Sevices
{
    public class PatientRepository : IPatientRepository
    {
        private readonly VaccinationDataContext context;

        public PatientRepository(VaccinationDataContext context)
        {
            this.context = context;
        }

        public async Task Create(Patient patient)
        {
            context.Patients.Add(patient);
            context.PatientProfiles.Add(patient.PatientProfile!);
            context.PatientResponses.Add(patient.VaccinationResponse!);

            await context.SaveChangesAsync();
        }
    }
}
