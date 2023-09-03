using VaccinationDataSystem.DataAccess;

namespace VaccinationDataSystem.Sevices
{
	public class VaccineRepository
	{
		private readonly VaccinationDataContext context;

		public VaccineRepository(VaccinationDataContext context)
        {
			this.context = context;
		}

		
    }
}
