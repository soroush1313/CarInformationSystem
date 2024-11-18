using AuthService.API.Models;

namespace AuthService.API.Repositories
{
    public interface ITokenRepository
    {
        Task SaveTokenAsync(Token token);
        Task<Token> GetTokenByUserIdAsync(string userId);
    }
}
