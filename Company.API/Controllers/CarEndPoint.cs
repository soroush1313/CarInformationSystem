using CarInformation.API.Models;
using CarInformation.API.Services.Interface;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarInformation.API.Controllers
{
    public static class CarEndPoint
    {
        public static void MapCarEndPoint(this WebApplication app)
        {
            app.MapGet("/cars", async (ICarService carService) =>
            {
                var cars = await carService.GetAllCarsAsync();
                return Results.Ok(cars);
            });

            app.MapGet("/cars/{id:int}", async (int id, ICarService carService) =>
            {
                var car = await carService.GetCarByIdAsync(id);
                return car is not null ? Results.Ok(car) : Results.NotFound();
            });

            app.MapPost("/cars", async (Car car, ICarService carService) =>
            {
                await carService.AddCarAsync(car);
                return Results.Created($"/cars/{car.Id}", car);
            });

            app.MapDelete("/cars", async (int id, ICarService carService) =>
            {
                await carService.DeleteCarAsync(id);
                return Results.NoContent();
            });

            //app.MapPut("/companies/{companyId:int}/cars/{carId:int}", async (int companyId , int carId , Car updatedCar , ICarService carService , ICompanyService companyService) =>
            //{
            //    try
            //    {
            //        var companyExists = await companyService.GetCompanyByIdAsync(companyId) != null;
            //        if (!companyExists)
            //        {
            //            return Results.NotFound($"Company with ID {companyId} not found.");
            //        }
            //        var cars = 

            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //})
        }
    }
}
