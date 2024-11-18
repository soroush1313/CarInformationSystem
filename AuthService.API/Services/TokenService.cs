
using AuthService.API.Models;
using AuthService.API.Repositories;

namespace AuthService.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public async Task SaveTokenAsync(string userId, string jwtToken, DateTime expiresAt)
        {
            var token = new Token
            {
                UserId = userId,
                JwtToken = jwtToken,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = expiresAt
            };

            await _tokenRepository.SaveTokenAsync(token);
        }
    }
}
