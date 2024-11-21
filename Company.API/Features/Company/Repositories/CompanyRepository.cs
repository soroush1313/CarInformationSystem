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
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return false;
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CarsCompany>> GetAllCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<CarsCompany> GetCompanyByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<CarsCompany> GetCompanywithCarsAsync(int id)
        {
            return await _context.Companies
                .Include(p => p.Cars)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateCompanyAsync(CarsCompany newcompany)
        {
            _context.Companies.Update(newcompany);
            await _context.SaveChangesAsync();
        }
    }
}
