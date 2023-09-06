using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalsRepository hospitalRepository;
        private readonly IVaccineRepository vaccineRepository;

        public HospitalController( IHospitalsRepository hospitalRepository,
            IVaccineRepository vaccineRepository)
        {
            this.hospitalRepository = hospitalRepository;
            this.vaccineRepository = vaccineRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await hospitalRepository.GetHospitalsAsync());
        }

        [HttpGet]
        public IActionResult HospitalAdditionForm()
        {
            return View("HospitalForm");
        }

        [HttpPost]
        public async Task<IActionResult> HospitalAdditionForm(Hospital hospital)
        {
            hospital.Vaccines = (List<Vaccine>)await vaccineRepository.GetVaccinesAsync();
            await hospitalRepository.CreateHospitalAsync(hospital);
            return View("Thanks", hospital);
        }
    }
}
