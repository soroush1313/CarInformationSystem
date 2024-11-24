using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Car.Queries;
using CarInformation.API.Features.Company.Commands;
using CarInformation.API.Features.Company.Queries;
using MediatR;

namespace CarInformation.API.Features.Company.Controllers
{
    public static class CompanyEndPoint
    {
        public static void MapCompanyEndPoint(this WebApplication app)
        {
            app.MapPost("/companies", async (CreateCompanyCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            });

            // Update Company
            app.MapPut("/companies/{id}", async (int id, UpdateCompanyCommand command, IMediator mediator) =>
            {
                command = command with { Id = id };
                await mediator.Send(command);
                return Results.NoContent();
            });

            // Delete Company
            app.MapDelete("/companies/{id}", async (int id, IMediator mediator) =>
            {
                await mediator.Send(new DeleteCompanyCommand(id));
                return Results.NoContent();
            });

            // Get Company by ID
            app.MapGet("/companies/{id}", async (int id, IMediator mediator) =>
            {
                var company = await mediator.Send(new GetCompanyByIdQuery(id));
                return company != null ? Results.Ok(company) : Results.NotFound();
            });

            // Get All Companies
            app.MapGet("/companies", async (IMediator mediator) =>
            {
                var companies = await mediator.Send(new GetAllCompaniesQuery());
                return Results.Ok(companies);
            });
        }
    }
}
