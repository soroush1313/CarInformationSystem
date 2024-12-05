using CarInformation.API.Data;
using CarInformation.API.Features.Car.Models;
using CarInformation.API.Features.Car.Repositories;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInformation.Test.Features.Car.Commands
{
    public class CreateCarCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_Should_Add_Car_To_Database()
        {
            //Arrange
            var dbContext = CreateTestDbContext();
            var carRepository = new CarRepository(dbContext);
            var unitOfWork = new UnitOfWork(dbContext);

            var car = new CarInformation.API.Features.Car.Models.Car
            {
                Model = "Tesla Model S",
                Color = "Red",
                HighestSpeed = 250
            };

            //Act
            await carRepository.AddCarAsync(car);
            await unitOfWork.SaveChangesAsync();

            //assert
            var addedCar = await dbContext.Cars.FirstOrDefaultAsync(c=>c.Model == "Tesla Model S");
            Assert.NotNull(addedCar);
            Assert.Equal("Red",addedCar.Color);
        }
    }
}
