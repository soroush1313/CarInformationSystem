using CarInformation.API.Models;

namespace CarInformation.API.Services.Interface
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetCarsByCompanyAsync(int companyId);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
        Task<Car> GetCarByIdAsync(int carId);
        Task<IEnumerable<Car>> GetAllCarsAsync();
    }
}
