using Azure;
using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Car.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarInformation.API.Features.Car.Controllers
{
    public static class CarEndPoint
    {
        public static void MapCarEndPoint(this WebApplication app)
        {
            app.MapPost("/cars", async (CreateCarCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            });

            app.MapPut("/cars/{id}", async (int id, UpdateCarCommand command, IMediator mediator) =>
            {
                command = command with { Id = id };
                await mediator.Send(command);
                return Results.NoContent();
            });

            app.MapDelete("/cars/{id}", async (int id, IMediator mediator) =>
            {
                await mediator.Send(new DeleteCarCommand(id));
                return Results.NoContent();
            });

            app.MapGet("/cars/{id}", async (int id, IMediator mediator) =>
            {
                var car = await mediator.Send(new GetCarByIdQuery(id));
                return car != null ? Results.Ok(car) : Results.NotFound();
            });

            app.MapGet("/cars", async (IMediator mediator) =>
            {
                var cars = await mediator.Send(new GetAllCarsQuery());
                return Results.Ok(cars);
            });
        }
    }
}
