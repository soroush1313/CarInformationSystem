using CarInformation.API.Data;
using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Car.Dtos;
using CarInformation.API.Features.Car.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarRepository _carRepository;

        public UpdateCarCommandHandler(IUnitOfWork unitOfWork, ICarRepository carRepository)
        {
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
        }

        public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetCarByIdAsync(request.Id);
            if (car == null) throw new KeyNotFoundException($"Car with ID {request.Id} not found");

            car.Model = request.Model;
            car.HighestSpeed = request.HighestSpeed;
            car.Color = request.Color;

            await _carRepository.UpdateCarAsync(car);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value; // Indicates success with no response.
        }
    }
}
