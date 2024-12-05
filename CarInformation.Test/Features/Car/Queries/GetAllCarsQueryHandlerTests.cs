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
    public class GetAllCarsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnListOfCars_WhenCarsExist()
        {
            //Arrange
            var carRepository = Substitute.For<ICarRepository>();
            var car = new List<API.Features.Car.Models.Car>
            {
                new API.Features.Car.Models.Car
                {
                    Id = 1,
                    Model = "Test1",
                    Color = "Black",
                    HighestSpeed = 100,
                },
                new API.Features.Car.Models.Car
                {
                    Id= 2,
                    Model = "Test2",
                    Color= "White",
                    HighestSpeed = 200,
                }
            };

            carRepository.GetAllCarsAsync().Returns(car);

            var handler = new GetAllCarsQueryHandler(carRepository);
            var query = new GetAllCarsQuery();

            //Act
            var result = await handler.Handle(query,CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2,result.Count());

            Assert.Contains(result , c=> c.Id == 1 && c.Model == "Test1" && c.Color == "Black" && c.HighestSpeed == 100);
            Assert.Contains(result , c=> c.Id == 2 && c.Model == "Test2" && c.Color == "White" && c.HighestSpeed == 200);

            await carRepository.Received(1).GetAllCarsAsync();
        }
    }
}
