namespace AuthService.API.Models
{
    public class Token
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string JwtToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
