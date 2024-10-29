using CarInformation.API.Models;
using CarInformation.API.Services.Interface;

namespace Company.API.Controllers
{
    public static class CompanyEndPoint
    {
        public static void MapCompanyEndPoint(this WebApplication app)
        {
            app.MapGet("/companies", async (ICompanyService companyService) =>
            {
                var companies = await companyService.GetAllCompaniesAsync();
                return Results.Ok(companies);
            });

            app.MapGet("/companies/{id:int}", async (int id, ICompanyService companyService) =>
            {
                var company = await companyService.GetCompanyByIdAsync(id);
                return company is not null ? Results.Ok(company) : Results.NotFound();
            });

            app.MapGet("/companies/{id:int}/cars", async (int id, ICompanyService companyService) =>
            {
                var companyWithCars = await companyService.GetCompanywithCarsAsync(id);
                return companyWithCars is not null ? Results.Ok(companyWithCars) : Results.NotFound();
            });

            app.MapPost("/companies", async (CarsCompany company, ICompanyService companyService) =>
            {
                await companyService.AddCompanyAsync(company);
                return Results.Created($"/companies/{company.Id}", company);
            });

            app.MapDelete("/companies/{id:int}", async (int id, ICompanyService companyService) =>
            {
                await companyService.DeleteCompanyAsync(id);
                return Results.NoContent();
            });

            app.MapPut("/companies/{id:int}", async (int id, CarsCompany updatedCompany, ICompanyService companyService) =>
            {
                var existingCompany = await companyService.GetCompanyByIdAsync(id);
                if (existingCompany == null)
                {
                    return Results.NotFound($"Company with ID {id} not found!");
                }
                existingCompany.CompanyName = updatedCompany.CompanyName;
                existingCompany.Country = updatedCompany.Country;
                await companyService.UpdateCompanyAsync(existingCompany);
                return Results.NoContent();
            });
        }
    }
}
