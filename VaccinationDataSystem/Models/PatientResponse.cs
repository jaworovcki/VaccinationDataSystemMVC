namespace VaccinationDataSystem.Models
{
	public class PatientResponse
	{
		public int Id { get; set; }

		public Patient? Patient { get; set; }

        public int PatientId { get; set; }

        public bool? WillVaccine { get; set; }

    }

}
