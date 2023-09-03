using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Interfaces
{
    public interface IHospitalsRepository
    {
        Task CreateHospitalAsync(Hospital hospital);

        Task<IList<Hospital>> GetHospitalsAsync();

        Task<Hospital> GetHospitalByIdAsync(int id);

        Task DeleteHospitalByIdAsync(int id);

    }
}
