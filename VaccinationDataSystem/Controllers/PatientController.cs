using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;
using VaccinationDataSystem.Sevices;

namespace VaccinationDataSystem.Controllers
{
	public class PatientController : Controller
	{
		private readonly VaccinationDataContext context;
        private readonly IPatientRepository repository;

        public PatientController(VaccinationDataContext context, IPatientRepository repository)
        {
			this.context = context;
            this.repository = repository;
        }

		[HttpGet("register")]
		public IActionResult GetRegisterForm()
		{
			return View("RegisterForm");
		}

		[HttpPost("register")]
		public async Task<IActionResult> PostRegisterForm(Patient patient)
		{
			await repository.CreateAsync(patient);
			return View("RegisterForm", patient);
		}



    }
}
