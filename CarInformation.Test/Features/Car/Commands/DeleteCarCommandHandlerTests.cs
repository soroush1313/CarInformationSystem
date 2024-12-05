using CarInformation.API.Data;
using CarInformation.API.Features.Car.Commands;
using CarInformation.API.Features.Car.Handlers;
using CarInformation.API.Features.Car.Repositories.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInformation.Test.Features.Car.Commands
{
    public class DeleteCarCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_ShouldDeleteCar_WhenCarExists()
        {
            //Arrange
            var carRepository = Substitute.For<ICarRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var car = new CarInformation.API.Features.Car.Models.Car
            {
                Id = 1,
                Color = "Black",
                HighestSpeed = 100,
                Model = "Test"
            };
            carRepository.GetCarByIdAsync(car.Id).Returns(car);
            var handler = new DeleteCarCommandHandler(unitOfWork, carRepository);
            var command = new DeleteCarCommand(1);

            //Act
            await handler.Handle(command, CancellationToken.None);

            //assert
            await carRepository.Received(1).GetCarByIdAsync(1);
            await carRepository.Received(1).DeleteCarAsync(1);
            await unitOfWork.Received(1).SaveChangesAsync();
        }
    }
}
