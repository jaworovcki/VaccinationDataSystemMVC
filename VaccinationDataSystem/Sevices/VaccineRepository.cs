using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Sevices
{
	public class VaccineRepository : IVaccineRepository
	{
		private readonly VaccinationDataContext context;

		public VaccineRepository(VaccinationDataContext context)
        {
			this.context = context;
		}

		public async Task CreateVaccineAsync(Vaccine vaccine)
		{
			context.Add(vaccine);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Vaccine>> GetVaccinesAsync()
			=> await context.Vaccines.AsNoTracking().ToListAsync();

		public async Task<Vaccine> GetVaccineByIdAsync(int id) 
			=> await context.Vaccines.SingleOrDefaultAsync(x => x.Id == id);

		public async Task DeleteVaccineByIdAsync(int id)
		{
			var vaccine = await GetVaccineByIdAsync(id);
			context.Vaccines.Remove(vaccine);
			await context.SaveChangesAsync();
		}

	}
}
