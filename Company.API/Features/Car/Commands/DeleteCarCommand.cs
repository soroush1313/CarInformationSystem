using CarInformation.API.Features.Car.Dtos;
using MediatR;

namespace CarInformation.API.Features.Car.Commands
{
    public record DeleteCarCommand(int Id) : IRequest<Unit>;
}
