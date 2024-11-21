using System.Text.Json.Serialization;
using CarInformation.API.Features.Car.Models;

namespace CarInformation.API.Features.Company.Models
{
    public class CarsCompany
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        //[JsonIgnore]
        public List<Features.Car.Models.Car>? Cars { get; set; } = new List<Features.Car.Models.Car>();
    }
}
