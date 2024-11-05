using CarInformation.API.Models;
using MediatR;

namespace CarInformation.API.Features.Company.Commands
{
        public record UpdateCompanyCommand(int Id , string CompanyName, string Country) : IRequest<CarsCompany>;
}
