using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;

namespace VaccinationDataSystem.Controllers
{
	public class VaccineController : Controller
	{
		private readonly VaccinationDataContext context;

		public VaccineController(VaccinationDataContext context)
        {
			this.context = context;
		}


    }
}
