namespace AuthService.API.Services
{
    public interface ITokenService
    {
        Task SaveTokenAsync(string userId, string jwtToken, DateTime expiresAt);
    }
}
