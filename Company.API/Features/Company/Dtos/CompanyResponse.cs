namespace CarInformation.API.Features.Company.Dtos
{
    public class CompanyResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public List<CarDto>? Cars { get; set; }
    }
}
