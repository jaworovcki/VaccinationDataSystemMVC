using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Controllers
{
	public class PatientController : Controller
	{
		private readonly VaccinationDataContext context;

		public PatientController(VaccinationDataContext context)
        {
			this.context = context;
		}

		[HttpGet("register")]
		public IActionResult GetRegisterForm()
		{
			return View("RegisterForm");
		}

		[HttpPost("register")]
		public IActionResult PostRegisterForm(Patient patient)
		{
			return View("RegisterForm", patient);
		}



    }
}
