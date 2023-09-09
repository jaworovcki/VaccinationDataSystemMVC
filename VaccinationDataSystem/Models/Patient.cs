using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace VaccinationDataSystem.Models
{
	public class Patient
	{
		public int Id { get; set; }

		[Required]
		[Phone]
		public string Phone { get; set; } = string.Empty;

		[EmailAddress]
		public string? Email { get; set; }

        public PatientProfile? PatientProfile { get; set; }

		public Hospital? HostHospital { get; set; }

        public int HostHospitalId { get; set; }

        public PatientResponse? VaccinationResponse { get; set; }

		[NotMapped]
		public List<Hospital> AvalaibleHospital { get; set; } = new();
    }
}
