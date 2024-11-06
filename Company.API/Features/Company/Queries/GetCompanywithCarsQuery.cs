using CarInformation.API.Models;
using MediatR;

namespace CarInformation.API.Features.Company.Queries
{
    public record GetCompanywithCarsQuery(int Id) : IRequest<CarsCompany>;
}
