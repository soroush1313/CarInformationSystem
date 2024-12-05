using CarInformation.API.Data;
using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Car.Handlers;
using CarInformation.API.Features.Car.Repositories;
using CarInformation.API.Features.Car.Repositories.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInformation.Test.Features.Car.Commands
{
    public class UpdateCarCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_Should_Update_Car_In_Database()
        {
            //arrange
            // Mock the repository and unit of work
            var carRepository = Substitute.For<ICarRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            // Create a handler with the mocks
            var handler = new UpdateCarCommandHandler(unitOfWork, carRepository);


            // Command to update the car
            var command = new UpdateCarCommand(
            
                Id : 1,
                Model : "Updated Model",
                HighestSpeed: 300,
                Color: "Black"
            );

            // Mock existing car
            var existingCar = new CarInformation.API.Features.Car.Models.Car
            {
                Id = 1,
                Model = "Old Model",
                Color = "White",
                HighestSpeed = 200
            };

            // Setup repository to return the existing car
            carRepository.GetCarByIdAsync(command.Id).Returns(existingCar);

            // Act
            await handler.Handle(command, CancellationToken.None);

            //Assert
            // Verify the car's properties are updated
            Assert.Equal("Updated Model", existingCar.Model);
            Assert.Equal("Black", existingCar.Color);
            Assert.Equal(300, existingCar.HighestSpeed);

            // Verify SaveChangesAsync is called
            await unitOfWork.Received(1).SaveChangesAsync();

            // Verify repository methods are called as expected
            await carRepository.Received(1).GetCarByIdAsync(command.Id);
        }
    }
}
