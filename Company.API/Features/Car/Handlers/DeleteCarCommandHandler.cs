using CarInformation.API.Data;
using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Car.Dtos;
using CarInformation.API.Features.Car.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarRepository _carRepository;

        public DeleteCarCommandHandler(IUnitOfWork unitOfWork, ICarRepository carRepository)
        {
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
        }

        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetCarByIdAsync(request.Id);
            if (car == null) throw new KeyNotFoundException($"Car with ID {request.Id} not found");

            await _carRepository.DeleteCarAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value; // Indicates success with no response.
        }
    }
}
