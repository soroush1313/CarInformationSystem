using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Features.Company.Models;
using CarInformation.API.Features.Company.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class UpdateCompanyCommandHandler: IRequestHandler<UpdateCompanyCommand , CarsCompany>
    {
        private readonly ICompanyRepository _companyRepository;
        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CarsCompany> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(request.Id);
            if (company == null)
            {
                return null;
            }

            company.CompanyName = request.CompanyName;
            company.Country = request.Country;  

            await _companyRepository.UpdateCompanyAsync(company);
            return company;
        }
    }
}
