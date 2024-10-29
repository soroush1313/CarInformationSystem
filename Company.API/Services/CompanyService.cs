using CarInformation.API.Models;
using CarInformation.API.Repositories.Interface;
using CarInformation.API.Services.Interface;

namespace CarInformation.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task AddCompanyAsync(CarsCompany company)
        {
            await _companyRepository.AddCompanyAsync(company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _companyRepository.DeleteCompanyAsync(id);
        }

        public async Task<IEnumerable<CarsCompany>> GetAllCompaniesAsync()
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }

        public async Task<CarsCompany> GetCompanyByIdAsync(int id)
        {
            return await _companyRepository.GetCompanyByIdAsync(id);
        }

        public async Task<CarsCompany> GetCompanywithCarsAsync(int id)
        {
            return await _companyRepository.GetCompanywithCarsAsync(id);
        }

        public async Task UpdateCompanyAsync(CarsCompany company)
        {
            await _companyRepository.UpdateCompanyAsync(company);
        }
    }
}
