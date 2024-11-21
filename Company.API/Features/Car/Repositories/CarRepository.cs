using CarInformation.API.Data;
using CarInformation.API.Features.Car.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using CarInformation.API.Features.Car.Models;

namespace CarInformation.API.Features.Car.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CompanyDbContext _context;
        public CarRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddCarAsync(Features.Car.Models.Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return false;
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Features.Car.Models.Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Features.Car.Models.Car> GetCarByIdAsync(int carId)
        {
            return await _context.Cars.FindAsync(carId);
        }

        public async Task<IEnumerable<Features.Car.Models.Car>> GetCarsByCompanyAsync(int companyId)
        {
            return await _context.Cars.Where(a => a.CompanyId == companyId).ToListAsync();
        }

        public async Task UpdateCarAsync(Features.Car.Models.Car car)
        {
            var existingCar = await _context.Cars.FindAsync(car.Id);
            if (existingCar != null)
            {
                existingCar.Model = car.Model;
                existingCar.Color = car.Color;
                existingCar.HighestSpeed = car.HighestSpeed;
                _context.Entry(existingCar).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
