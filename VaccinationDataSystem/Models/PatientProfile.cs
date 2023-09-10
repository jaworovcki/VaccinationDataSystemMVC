using System.ComponentModel.DataAnnotations;

namespace VaccinationDataSystem.Models
{
	public class PatientProfile
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(150)]
		public string Name { get; set; } = string.Empty;

		[Range(16,100)]
		public int Age { get; set; }

		public bool? IsMarried { get; set; }

		public Patient? Patient { get; set; }

        public int PatientId { get; set; }
    }
}
