using CarInformation.API.Features.Car.Dtos;
using MediatR;

namespace CarInformation.API.Features.Car.Commands
{
    public record UpdateCarCommand(int Id , string Model, int HighestSpeed, string Color/*, int CompanyId*/) : IRequest<Unit>;
}
