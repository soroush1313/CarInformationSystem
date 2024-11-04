using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Company.Handlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly ICompanyRepository _companyRepository;
        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(DeleteCompanyCommand request , CancellationToken cancellationToken)
        {
            return await _companyRepository.DeleteCompanyAsync(request.Id);
        }
    }
}
