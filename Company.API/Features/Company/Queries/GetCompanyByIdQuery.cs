using CarInformation.API.Features.Company.Dtos;
using MediatR;

namespace CarInformation.API.Features.Company.Queries
{
    public record GetCompanyByIdQuery(int Id) : IRequest<CompanyResponse>;
}
