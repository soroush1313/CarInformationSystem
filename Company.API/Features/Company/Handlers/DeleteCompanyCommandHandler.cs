using CarInformation.API.Data;
using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Features.Company.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.Companies.GetCompanyByIdAsync(request.Id);
            if (company == null)
                throw new Exception("Company not found.");

            await _unitOfWork.Companies.DeleteCompanyAsync(company.Id);
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
