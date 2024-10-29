using CarInformation.API.Models;
using CarInformation.API.Repositories.Interface;
using CarInformation.API.Services.Interface;

namespace CarInformation.API.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task AddCarAsync(Car car)
        {
            await _carRepository.AddCarAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteCarAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllCarsAsync();
        }

        public async Task<Car> GetCarByIdAsync(int carId)
        {
            return await _carRepository.GetCarByIdAsync(carId);
        }

        public async Task<IEnumerable<Car>> GetCarsByCompanyAsync(int companyId)
        {
            return await _carRepository.GetCarsByCompanyAsync(companyId);
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _carRepository.UpdateCarAsync(car);
        }
    }
}
