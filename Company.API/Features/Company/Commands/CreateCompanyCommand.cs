using CarInformation.API.Features.Company.Models;
using MediatR;
using System.Diagnostics.Metrics;

namespace CarInformation.API.Features.Company.Commands
{
    public record CreateCompanyCommand(string CompanyName , string Country) : IRequest<Unit>;
}
