using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Interfaces
{
    public interface IPatientRepository
    {
        Task CreateAsync(Patient patient);
    }
}
