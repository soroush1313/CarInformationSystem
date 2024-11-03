using MediatR;

namespace CarInformation.API.Features.Car.Commands
{
    public record UpdateCarCommand(int Id , string Model, int HighestSpeed, string Color, int CompanyId) : IRequest<Models.Car>;
}
