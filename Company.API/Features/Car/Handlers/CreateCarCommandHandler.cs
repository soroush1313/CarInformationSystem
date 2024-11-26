using CarInformation.API.Data;
using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Car.Dtos;
using CarInformation.API.Features.Car.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(IUnitOfWork unitOfWork, ICarRepository carRepository)
        {
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
        }

        public async Task<Unit> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Models.Car
            {
                Model = request.Model,
                HighestSpeed = request.HighestSpeed,
                Color = request.Color,
                CompanyId = request.CompanyId
            };

            await _carRepository.AddCarAsync(car);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
