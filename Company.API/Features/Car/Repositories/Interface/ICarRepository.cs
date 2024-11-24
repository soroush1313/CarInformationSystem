using CarInformation.API.Features.Car.Dtos;
using CarInformation.API.Features.Car.Models;

namespace CarInformation.API.Features.Car.Repositories.Interface
{
    public interface ICarRepository
    {
        Task AddCarAsync(Models.Car car);
        Task<Models.Car> GetCarByIdAsync(int id);
        Task<IEnumerable<Models.Car>> GetAllCarsAsync();
        Task UpdateCarAsync(Models.Car car);
        Task DeleteCarAsync(int id);
    }
}
