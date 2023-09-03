using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Interfaces
{
    public interface IPatientRepository
    {
        Task Create(Patient patient);
    }
}
