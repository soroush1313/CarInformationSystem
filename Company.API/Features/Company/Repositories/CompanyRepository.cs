using CarInformation.API.Data;
using CarInformation.API.Features.Company.Models;
using CarInformation.API.Features.Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarInformation.API.Features.Company.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyDbContext _context;
        public CompanyRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanyAsync(CarsCompany company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await GetCompanyByIdAsync(id);
            if (company != null) _context.Companies.Remove(company);
        }

        public async Task<IEnumerable<CarsCompany>> GetAllCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<CarsCompany> GetCompanyByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task UpdateCompanyAsync(CarsCompany newcompany)
        {
            _context.Companies.Update(newcompany);
        }
    }
}
