﻿using CarInformation.API.Data;
using CarInformation.API.Features.Car.Dtos;
using CarInformation.API.Features.Car.Queries;
using CarInformation.API.Features.Car.Repositories.Interface;
using MediatR;

namespace CarInformation.API.Features.Car.Handlers
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CarResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _unitOfWork.Cars.GetAllCarsAsync();

            return cars.Select(car => new CarResponse
            {
                Id = car.Id,
                Model = car.Model,
                HighestSpeed = car.HighestSpeed,
                Color = car.Color,
                CompanyId = car.CompanyId
            });
        }
    }
}
