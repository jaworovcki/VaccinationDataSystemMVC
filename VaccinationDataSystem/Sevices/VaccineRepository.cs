using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Models;

namespace VaccinationDataSystem.Sevices
{
	public class VaccineRepository : IVaccineRepository
	{
		private readonly VaccinationDataContext context;
		private const string filePathForVaccines = @"C:\dotnet\aspnet\VaccinationDataSystemMVC\VaccinationDataSystem\assets\Vaccines.csv";

		public VaccineRepository(VaccinationDataContext context)
        {
			this.context = context;
		}

		public async Task CreateVaccineAsync(Vaccine vaccine)
		{
			context.Add(vaccine);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Vaccine>> GetVaccinesAsync()
			=> await context.Vaccines.AsNoTracking().ToListAsync();

		public async Task<Vaccine> GetVaccineByIdAsync(int id) 
			=> await context.Vaccines.SingleOrDefaultAsync(x => x.Id == id);

		public async Task DeleteVaccineByIdAsync(int id)
		{
			var vaccine = await GetVaccineByIdAsync(id);
			context.Vaccines.Remove(vaccine);
			await context.SaveChangesAsync();
		}
		
		public async Task ImportVaccinesFromCSVAsync()
		{
			var config = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				Delimiter = ",",
				HasHeaderRecord = true,
				TrimOptions = TrimOptions.Trim,
				MissingFieldFound = null
			};

			using (var reader = new StreamReader(filePathForVaccines))
			{
				using (var csv = new CsvReader(reader, config))
				{
					await csv.ReadAsync()
						.ContinueWith(_ => csv.ReadHeader());
                    var records = csv.GetRecords<Vaccine>().ToArray();
                    foreach (var record in records)
					{
						if (!context.Vaccines.Any(v => v.Name == record.Name))
							await CreateVaccineAsync(record);
                    }
                }
			}
		}
	}
}
