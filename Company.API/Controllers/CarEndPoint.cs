using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Car.Queries;
using CarInformation.API.Models;
using CarInformation.API.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarInformation.API.Controllers
{
    public static class CarEndPoint
    {
        public static void MapCarEndPoint(this WebApplication app)
        {
            app.MapPost("/cars", async (CreateCarCommand command, IMediator mediator) =>
            {
                var car = await mediator.Send(command);
                return Results.Created($"/cars/{car.Id}", car);
            });

            app.MapGet("/cars/{id}", async (int id, IMediator mediator) =>
            {
                var car = await mediator.Send(new GetCarByIdQuery(id));
                return car is not null ? Results.Ok(car) : Results.NotFound();
            });

            app.MapGet("/cars", async (IMediator mediator) =>
            {
                var cars = await mediator.Send(new GetAllCarsQuery());
                return Results.Ok(cars);
            });

            app.MapPut("/cars/{id}", async (int id, UpdateCarCommand command, IMediator mediator) =>
            {
                if (id != command.Id)
                    return Results.BadRequest();
                var updatedCar = await mediator.Send(command);
                return updatedCar is not null ? Results.Ok(updatedCar) : Results.NotFound();
            });

            app.MapDelete("/cars/{id}", async (int id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteCarCommand(id));
                return result ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
