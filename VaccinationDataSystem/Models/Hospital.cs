using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationDataSystem.Models
{
	public class Hospital
	{
		public int Id { get; set; }

		[Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

		[MaxLength(250)]
		public string Location { get; set; } = string.Empty;

        public List<Patient> Patients { get; set; } = new();

        [NotMapped]
        public List<Vaccine> AvalableVaccines { get; set; } = new();

        public List<Vaccine> Vaccines { get; set; } = new();

    }
}
