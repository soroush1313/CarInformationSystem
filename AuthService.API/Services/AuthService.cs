using AuthService.API.Models;

namespace AuthService.API.Services
{
    public class AuthService : IAuthService
    {
        public Task<AuthResponse> AuthenticateUserAsync(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse> RegisterUserAsync(UserRegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
