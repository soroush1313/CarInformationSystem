using MediatR;

namespace CarInformation.API.Features.Company.Commands
{
    public record DeleteCompanyCommand(int Id) : IRequest<Unit>;
}
