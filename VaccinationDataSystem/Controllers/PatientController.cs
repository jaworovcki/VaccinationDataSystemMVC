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
        private readonly IHospitalsRepository hospitalsRepository;

        public PatientController(VaccinationDataContext context,
			IPatientRepository repository,
			IHospitalsRepository hospitalsRepository)
        {
			this.context = context;
            this.repository = repository;
            this.hospitalsRepository = hospitalsRepository;
        }

		[HttpGet("register")]
		public async Task<IActionResult> GetRegisterForm()
		{
			var patient = new Patient();
            patient.AvalaibleHospital = (List<Hospital>)await hospitalsRepository.GetHospitalsAsync();
			return View("RegisterForm", patient);
		}

		[HttpPost("register")]
		public async Task<IActionResult> PostRegisterForm(Patient patient)
		{
			await repository.CreateAsync(patient);
			return View("RegisterForm", patient);
		}
    }
}
