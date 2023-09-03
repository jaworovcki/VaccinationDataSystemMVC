using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Controllers
{
    public class HospitalController : Controller
    {
        private readonly VaccinationDataContext context;
        private readonly IHospitalsRepository repository;

        public HospitalController(VaccinationDataContext context, IHospitalsRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repository.GetHospitalsAsync());
        }

        [HttpGet]
        public IActionResult HospitalAdditionForm()
        {
            return View("HospitalForm");
        }

        [HttpPost]
        public async Task<IActionResult> HospitalAdditionForm(Hospital hospital)
        {
            await repository.CreateHospitalAsync(hospital);
            return View("HospitalForm", hospital);
        }
    }
}
