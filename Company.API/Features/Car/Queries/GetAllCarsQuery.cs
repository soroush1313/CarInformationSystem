using MediatR;

namespace CarInformation.API.Features.Car.Queries
{
    public record GetAllCarsQuery : IRequest<IEnumerable<Models.Car>>;
}
