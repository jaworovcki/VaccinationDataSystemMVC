using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;

namespace VaccinationDataSystem.Controllers
{
	public class VaccineController : Controller
	{
		private readonly VaccinationDataContext context;
		private readonly IVaccineRepository repository;

		public VaccineController(VaccinationDataContext context, IVaccineRepository repository)
        {
			this.context = context;
			this.repository = repository;
		}

		public async Task<IActionResult> Index()
		{
			return View(await repository.GetVaccinesAsync());
		}

		public IActionResult VaccinesAdditionForm()
		{
			return View("VaccineForm");
		}


    }
}
