using Microsoft.EntityFrameworkCore;

namespace VaccinationDataSystem.DataAccess
{
	public class VaccinationDataContext : DbContext
	{
        public VaccinationDataContext(DbContextOptions<VaccinationDataContext> options)
            : base(options)
        {
            
        }
    }
}
