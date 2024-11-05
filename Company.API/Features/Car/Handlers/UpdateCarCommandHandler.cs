using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Models.Car>
    {
        private readonly ICarRepository _carRepository;
        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Models.Car> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetCarByIdAsync(request.Id);
            if (car == null)
                return null;

            car.Color = request.Color;
            car.Model = request.Model;
            car.HighestSpeed = request.HighestSpeed;
            //car.CompanyId = request.CompanyId;
            await _carRepository.UpdateCarAsync(car);
            return car;
        }
    }
}
