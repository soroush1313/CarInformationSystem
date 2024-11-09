using AuthService.API.Models;

namespace AuthService.API.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterUserAsync(UserRegistrationRequest request);
        Task<AuthResponse> AuthenticateUserAsync(UserLoginRequest request);
    }
}
