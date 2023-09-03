using Microsoft.EntityFrameworkCore;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Sevices
{
    public class HospitalsRepository : IHospitalsRepository
    {
        private readonly VaccinationDataContext context;
        
        public HospitalsRepository(VaccinationDataContext context)
        {
            this.context = context;
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
