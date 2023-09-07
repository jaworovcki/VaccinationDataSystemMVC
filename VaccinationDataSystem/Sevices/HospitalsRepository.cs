using Microsoft.EntityFrameworkCore;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Sevices
{
    public class HospitalsRepository : IHospitalsRepository
    {
        private readonly VaccinationDataContext context;
		private readonly IVaccineRepository _vaccineRepository;

		public HospitalsRepository(VaccinationDataContext context, IVaccineRepository vaccineRepository)
        {
            this.context = context;
			_vaccineRepository = vaccineRepository;
		}

        public async Task CreateHospitalAsync(Hospital hospital)
        {
			context.Hospitals.Add(hospital);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Hospital>> GetHospitalsAsync() 
            => await context.Hospitals.AsNoTracking().ToListAsync();

        public async Task<Hospital> GetHospitalByIdAsync(int id) 
            => await context.Hospitals.SingleOrDefaultAsync(h => h.Id == id);

        public async Task DeleteHospitalByIdAsync(int id)
        {
            var hospital = await GetHospitalByIdAsync(id);
            context.Remove(hospital);
            await context.SaveChangesAsync();
        }
    }
}
