using CarInformation.API.Features.Company.Queries;
using CarInformation.API.Models;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery , IEnumerable<CarsCompany>>
    {
        private readonly ICompanyRepository _companyRepository;
        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CarsCompany>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }
    }
}
