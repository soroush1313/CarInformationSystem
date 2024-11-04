using CarInformation.API.Features.Company.Queries;
using CarInformation.API.Models;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery , CarsCompany>
    {
        private readonly ICompanyRepository _companyRepository;
        public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CarsCompany> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _companyRepository.GetCompanyByIdAsync(request.Id);
        }
    }
}
