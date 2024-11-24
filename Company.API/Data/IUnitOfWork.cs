using CarInformation.API.Features.Car.Repositories.Interface;
using CarInformation.API.Features.Company.Repositories.Interface;

namespace CarInformation.API.Data
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
        ICompanyRepository Companies { get; }
        Task CompleteAsync();
    }
}
