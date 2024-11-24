using CarInformation.API.Features.Company.Dtos;
using CarInformation.API.Features.Company.Models;
using MediatR;

namespace CarInformation.API.Features.Company.Queries
{
    public record GetAllCompaniesQuery: IRequest<List<CompanyResponse>>;
}
