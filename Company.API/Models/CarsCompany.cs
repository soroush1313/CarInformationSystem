namespace CarInformation.API.Models
{
    public class CarsCompany
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public IList<Car> Cars { get; set; } = new List<Car>();
    }
}
