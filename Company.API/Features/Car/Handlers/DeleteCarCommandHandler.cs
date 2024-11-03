using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Models.Car>
    {
        private readonly ICarRepository _carRepository;
        public DeleteCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(DeleteCarCommand request , CancellationToken cancellationToken)
        {
            return await _carRepository.DeleteCarAsync(request.Id);
        }
    }
}
