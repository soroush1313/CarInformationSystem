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

        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
        }

        // Save all changes to the database
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
