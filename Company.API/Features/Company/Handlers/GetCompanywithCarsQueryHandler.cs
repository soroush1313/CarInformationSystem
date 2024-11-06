using CarInformation.API.Features.Company.Queries;
using CarInformation.API.Models;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class GetCompanywithCarsQueryHandler : IRequestHandler<GetCompanywithCarsQuery, CarsCompany>
    {
        private readonly ICompanyRepository _companyRepository;
        public GetCompanywithCarsQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CarsCompany> Handle(GetCompanywithCarsQuery request , CancellationToken cancellationToken)
        {
            return await _companyRepository.GetCompanywithCarsAsync(request.Id);
        }
    }
}
