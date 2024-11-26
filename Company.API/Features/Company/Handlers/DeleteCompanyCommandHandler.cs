using CarInformation.API.Data;
using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Features.Company.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(request.Id);
            if (company == null)
                throw new Exception("Company not found.");

            await _companyRepository.DeleteCompanyAsync(company.Id);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
