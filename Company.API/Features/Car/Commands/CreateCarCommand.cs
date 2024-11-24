using MediatR;

namespace CarInformation.API.Features.Car.Commands
{
    public record CreateCarCommand(string Model, int HighestSpeed, string Color, int CompanyId) : IRequest<Unit>;
}
