namespace CarInformation.API.Features.Car.Dtos
{
    public class CarResponse
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int HighestSpeed { get; set; }
        public string Color { get; set; }
        public int CompanyId { get; set; }
    }
}
