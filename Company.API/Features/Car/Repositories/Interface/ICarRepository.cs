using CarInformation.API.Features.Car.Models;

namespace CarInformation.API.Features.Car.Repositories.Interface
{
    public interface ICarRepository
    {
        Task<IEnumerable<Features.Car.Models.Car>> GetCarsByCompanyAsync(int companyId);
        Task AddCarAsync(Features.Car.Models.Car car);
        Task UpdateCarAsync(Features.Car.Models.Car car);
        Task<bool> DeleteCarAsync(int id);
        Task<Features.Car.Models.Car> GetCarByIdAsync(int carId);
        Task<IEnumerable<Features.Car.Models.Car>> GetAllCarsAsync();
    }
}
