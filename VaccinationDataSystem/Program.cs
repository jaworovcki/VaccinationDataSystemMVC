using Microsoft.EntityFrameworkCore;
using VaccinationDataSystem.DataAccess;
using VaccinationDataSystem.Interfaces;
using VaccinationDataSystem.Sevices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VaccinationDataContext>(options => options.UseSqlServer(
	builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IHospitalsRepository, HospitalsRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
