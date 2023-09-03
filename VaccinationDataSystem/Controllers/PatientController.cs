using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;

namespace VaccinationDataSystem.Controllers
{
	public class PatientController : Controller
	{
		private readonly VaccinationDataContext context;

		public PatientController(VaccinationDataContext context)
        {
			this.context = context;
		}

    }
}
