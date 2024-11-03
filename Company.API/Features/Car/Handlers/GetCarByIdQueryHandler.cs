using CarInformation.API.Features.Car.Queries;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery , Models.Car>
    {
        private readonly ICarRepository _carRepository;
        public GetCarByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Models.Car> Handle(GetCarByIdQuery request , CancellationToken cancellationToken)
        {
            return await _carRepository.GetCarByIdAsync(request.Id);
        }
    }
}
