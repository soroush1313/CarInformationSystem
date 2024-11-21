using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Features.Company.Models;
using CarInformation.API.Features.Company.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CarsCompany>
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CarsCompany> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new CarsCompany
            {
                CompanyName = request.CompanyName,
                Country = request.Country
            };
            await _companyRepository.AddCompanyAsync(company);
            return company;
        }
    }
}
