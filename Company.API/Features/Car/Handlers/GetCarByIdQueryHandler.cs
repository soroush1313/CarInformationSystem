using CarInformation.API.Data;
using CarInformation.API.Features.Car.Dtos;
using CarInformation.API.Features.Car.Queries;
using CarInformation.API.Features.Car.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarResponse>
    {
        private readonly ICarRepository _carRepository;

        public GetCarByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarResponse> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetCarByIdAsync(request.Id);
            if (car == null) throw new KeyNotFoundException($"Car with ID {request.Id} not found");

            return new CarResponse
            {
                Id = car.Id,
                Model = car.Model,
                HighestSpeed = car.HighestSpeed,
                Color = car.Color,
                CompanyId = car.CompanyId
            };
        }
    }
}
