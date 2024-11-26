using CarInformation.API.Data;
using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Features.Company.Models;
using CarInformation.API.Features.Company.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(request.Id);
            if (company == null)
                throw new Exception("Company not found.");

            company.CompanyName = request.CompanyName;
            company.Country = request.Country;

            await _companyRepository.UpdateCompanyAsync(company);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
