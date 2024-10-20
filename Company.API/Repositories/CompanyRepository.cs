using CarInformation.API.Data;
using CarInformation.API.Models;
using CarInformation.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarInformation.API.Repositories
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

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
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
            var existingCompany = await _context.Companies.FindAsync(newcompany.Id);
            if(existingCompany != null)
            {
                existingCompany.CompanyName = newcompany.CompanyName;
                existingCompany.Country = newcompany.Country;
                _context.Entry(existingCompany).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
