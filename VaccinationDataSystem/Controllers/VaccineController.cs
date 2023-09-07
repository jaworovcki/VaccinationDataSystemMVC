using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;

namespace VaccinationDataSystem.Controllers
{
	public class VaccineController : Controller
	{
		private readonly IVaccineRepository repository;

		public VaccineController(IVaccineRepository repository)
        {
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View(await repository.GetVaccinesAsync());
		}

		[HttpPost]
		public async Task<IActionResult> ImportVaccinesFromCSV()
		{
			await repository.ImportVaccinesFromCSVAsync();
            return RedirectToAction("Index");
		}


    }
}
