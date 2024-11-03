using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Models;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Models.Car>
    {
        private readonly ICarRepository _carRepository;
        public CreateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Models.Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Models.Car
            {
                Model = request.Model,
                HighestSpeed = request.HighestSpeed,
                Color = request.Color,
                CompanyId = request.CompanyId
            };

            await _carRepository.AddCarAsync(car);
            return car;
        }
    }
}
