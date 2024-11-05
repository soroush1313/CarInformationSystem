using System.Text.Json.Serialization;

namespace CarInformation.API.Models
{
    public class CarsCompany
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        [JsonIgnore]
        public List<Car>? Cars { get; set; } = new List<Car>();
    }
}
