using CarInformation.API.Data;
using CarInformation.API.Features.Company.Dtos;
using CarInformation.API.Features.Company.Models;
using CarInformation.API.Features.Company.Queries;
using CarInformation.API.Features.Company.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompanyByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.Companies.GetCompanyByIdAsync(request.Id);
            if (company == null) return null;

            return new CompanyResponse
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
            };
        }
    }
}
