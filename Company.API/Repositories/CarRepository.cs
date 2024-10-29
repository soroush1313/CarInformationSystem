using CarInformation.API.Data;
using CarInformation.API.Models;
using CarInformation.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarInformation.API.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CompanyDbContext _context;
        public CarRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if(car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int carId)
        {
            return await _context.Cars.FindAsync(carId);
        }

        public async Task<IEnumerable<Car>> GetCarsByCompanyAsync(int companyId)
        {
            return await _context.Cars.Where(a => a.CompanyId == companyId).ToListAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            var existingCar = await _context.Cars.FindAsync(car.Id);
            if(existingCar != null)
            {
                existingCar.Model = car.Model;
                existingCar.Color = car.Color;
                _context.Entry(existingCar).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
