using MediatR;

namespace CarInformation.API.Features.Car.Commands
{
    public record DeleteCarCommand(int Id) : IRequest<bool>;
}
