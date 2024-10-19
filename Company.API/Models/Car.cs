namespace CarInformation.API.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int HighestSpeed { get; set; }
        public string Color { get; set; }
        public int CompanyId { get; set; }
        public CarsCompany Company { get; set; } = null!;
    }
}
