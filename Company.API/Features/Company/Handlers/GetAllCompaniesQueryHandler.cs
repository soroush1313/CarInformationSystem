using CarInformation.API.Data;
using CarInformation.API.Features.Company.Dtos;
using CarInformation.API.Features.Company.Models;
using CarInformation.API.Features.Company.Queries;
using CarInformation.API.Features.Company.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyResponse>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();

            return companies.Select(company => new CompanyResponse
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Country = company.Country,
                Cars = company.Cars?.Select(car => new CarDto
                {
                    Id = car.Id,
                    Model = car.Model,
                    Color = car.Color,
                    HighestSpeed = car.HighestSpeed
                }).ToList()
            }).ToList();
        }
    }
}
