using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Interfaces
{
	public interface IVaccineRepository
	{
		Task CreateVaccineAsync(Vaccine vaccine);

		Task<IEnumerable<Vaccine>> GetVaccinesAsync();

		Task<Vaccine> GetVaccineByIdAsync(int id);

		Task DeleteVaccineByIdAsync(int id);

		Task ImportVaccinesFromCSVAsync();

    }
}
