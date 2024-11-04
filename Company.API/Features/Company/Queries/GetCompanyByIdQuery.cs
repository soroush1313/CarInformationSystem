using CarInformation.API.Models;
using MediatR;

namespace CarInformation.API.Features.Company.Queries
{
    public record GetCompanyByIdQuery(int Id) : IRequest<CarsCompany>;
}
