using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationDataSystem.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150)]
        public string ProductionCountry { get; set; } = string.Empty;

        [Column(TypeName="decima(2,5)")]
        public decimal Dosage { get; set; }

		[Column(TypeName = "decima(2,5)")]
		public decimal PriceForUnit { get; set; }

        public List<Hospital> PlacesOfVaccination { get; set; } = new();

    }
}
