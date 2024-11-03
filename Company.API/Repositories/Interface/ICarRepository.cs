using CarInformation.API.Models;

namespace CarInformation.API.Repositories.Interface
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCarsByCompanyAsync(int companyId);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task<bool> DeleteCarAsync(int id);
        Task<Car> GetCarByIdAsync(int carId);
        Task<IEnumerable<Car>> GetAllCarsAsync();
    }
}
