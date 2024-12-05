using CarInformation.API.Features.Car.Handlers;
using CarInformation.API.Features.Car.Queries;
using CarInformation.API.Features.Car.Repositories.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInformation.Test.Features.Car.Queries
{
    public class GetCarByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnCar_WhenCarExists()
        {
            //Arrange
            var carRepository = Substitute.For<ICarRepository>();
            var car = new API.Features.Car.Models.Car { Id = 1, Color = "Black", HighestSpeed = 400, Model = "Test" };

            carRepository.GetCarByIdAsync(car.Id).Returns(car);
            
            var handler = new GetCarByIdQueryHandler(carRepository);
            var query = new GetCarByIdQuery(1);

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(car.Id , result.Id);
            Assert.Equal(car.Model , result.Model);
            Assert.Equal(car.Color , result.Color);
            Assert.Equal(car.HighestSpeed , result.HighestSpeed);
            await carRepository.Received(1).GetCarByIdAsync(1);
        }
    }
}
