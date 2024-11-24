namespace CarInformation.API.Features.Company.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int HighestSpeed { get; set; }
        public string Color { get; set; }
        public int CompanyId { get; set; }

    }
}
