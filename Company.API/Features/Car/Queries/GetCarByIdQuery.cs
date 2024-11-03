using CarInformation.API.Models;
using MediatR;

namespace CarInformation.API.Features.Car.Queries
{
    public record GetCarByIdQuery(int Id) : IRequest<Models.Car>;
}
