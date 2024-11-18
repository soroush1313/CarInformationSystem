using AuthService.API.Models;
using MongoDB.Driver;

namespace AuthService.API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IMongoCollection<Token> _tokensCollection;
        public TokenRepository(IMongoDatabase database)
        {
            _tokensCollection = database.GetCollection<Token>("Tokens");
        }
        public async Task<Token> GetTokenByUserIdAsync(string userId)
        {
            return await _tokensCollection.Find(t => t.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task SaveTokenAsync(Token token)
        {
            await _tokensCollection.InsertOneAsync(token);
        }
    }
}
