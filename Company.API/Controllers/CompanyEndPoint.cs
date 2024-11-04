using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Features.Company.Queries;
using CarInformation.API.Models;
using CarInformation.API.Services.Interface;
using MediatR;

namespace Company.API.Controllers
{
    public static class CompanyEndPoint
    {
        public static void MapCompanyEndPoint(this WebApplication app)
        {
            app.MapPost("companies", async (CreateCompanyCommand command, IMediator mediator) =>
            {
                var company = await mediator.Send(command);
                return Results.Created($"/companies/{company.Id}", company);
            });

            app.MapGet("companies", async (IMediator mediator) =>
            {
                var company = await mediator.Send(new GetAllCompaniesQuery());
                return Results.Ok(company);
            });

            app.MapGet("companies/{id}", async (int id, IMediator mediator) =>
            {
                var company = await mediator.Send(new GetCompanyByIdQuery(id));
                return company is not null ? Results.Ok(company) : Results.NotFound();
            });

            app.MapPut("companies/{id}", async (int id, UpdateCompanyCommand command, IMediator mediator) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest();
                }
                var updatedCompany = mediator.Send(command);
                return updatedCompany is not null ? Results.Ok(updatedCompany) : Results.NotFound();
            });

            app.MapDelete("companies/{id}", async (int id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteCompanyCommand(id));
                return result ? Results.NoContent() : Results.NotFound();
            });

        }
    }
}
