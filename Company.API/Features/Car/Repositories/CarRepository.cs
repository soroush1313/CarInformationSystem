using CarInformation.API.Data;
using CarInformation.API.Features.Car.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using CarInformation.API.Features.Car.Models;
using CarInformation.API.Features.Car.Dtos;

namespace CarInformation.API.Features.Car.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CompanyDbContext _context;

        public CarRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddCarAsync(Models.Car car)
        {
            await _context.Cars.AddAsync(car);
        }

        public async Task<Models.Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<IEnumerable<Models.Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task UpdateCarAsync(Models.Car car)
        {
            _context.Cars.Update(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await GetCarByIdAsync(id);
            if (car != null) _context.Cars.Remove(car);
        }
    }
}
