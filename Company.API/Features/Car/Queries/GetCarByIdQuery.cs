using CarInformation.API.Features.Car.Dtos;
using MediatR;

namespace CarInformation.API.Features.Car.Queries
{
    public record GetCarByIdQuery(int Id) : IRequest<CarResponse>;
}
