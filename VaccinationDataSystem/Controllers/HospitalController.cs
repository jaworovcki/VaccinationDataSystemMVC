using Microsoft.AspNetCore.Mvc;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;
using VaccinationDataSystem.Sevices;

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
        public async Task<IActionResult> HospitalAdditionForm()
        {
            var hospital = new Hospital();
            hospital.AvalableVaccines = (List<Vaccine>)await vaccineRepository.GetVaccinesAsync();
            if (!hospital.AvalableVaccines.Any())
            {
                throw new Exception("No vaccines in database");
            }
            return View("HospitalForm", hospital); 
        }

        [HttpPost]
        public async Task<IActionResult> HospitalAdditionForm(Hospital hospital)
        {
            await hospitalRepository.CreateHospitalAsync(hospital);
            return View("Thanks", hospital);
        }
    }
}
