using CarInformation.API.Models;

namespace CarInformation.API.Services.Interface
{
    public interface ICompanyService
    {
        Task<IEnumerable<CarsCompany>> GetAllCompaniesAsync();
        Task<CarsCompany> GetCompanyByIdAsync(int id);
        Task<CarsCompany> GetCompanywithCarsAsync(int id);
        Task AddCompanyAsync(CarsCompany company);
        Task UpdateCompanyAsync(CarsCompany company);
        Task DeleteCompanyAsync(int id);
    }
}
