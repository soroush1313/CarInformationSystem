using CarInformation.API.Features.Car.Queries;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery , IEnumerable<Models.Car>>
    {
        private readonly ICarRepository _carRepository;
        public GetAllCarsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;   
        }

        public async Task<IEnumerable<Models.Car>> Handle(GetAllCarsQuery request , CancellationToken cancellationToken)
        {
            return await _carRepository.GetAllCarsAsync();
        }
    }
}
