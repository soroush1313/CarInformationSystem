using CarInformation.API.Data;
using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Features.Company.Models;
using CarInformation.API.Features.Company.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new CarsCompany
            {
                CompanyName = request.CompanyName,
                Country = request.Country
            };

            await _companyRepository.AddCompanyAsync(company);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
