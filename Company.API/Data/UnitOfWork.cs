using CarInformation.API.Features.Car.Repositories.Interface;
using CarInformation.API.Features.Car.Repositories;
using CarInformation.API.Features.Company.Repositories.Interface;
using CarInformation.API.Features.Company.Repositories;
using System;

namespace CarInformation.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;
        private ICarRepository _carRepository;
        private ICompanyRepository _companyRepository;

        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
        }

        // Lazy instantiation of repositories
        public ICarRepository Cars => _carRepository ??= new CarRepository(_context);
        public ICompanyRepository Companies => _companyRepository ??= new CompanyRepository(_context);

        // Save all changes to the database
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
