using System.Text.Json.Serialization;
using CarInformation.API.Features.Company.Models;

namespace CarInformation.API.Features.Car.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int HighestSpeed { get; set; }
        public string Color { get; set; }
        public int CompanyId { get; set; }
        [JsonIgnore]
        public CarsCompany? Company { get; set; }
    }
}
