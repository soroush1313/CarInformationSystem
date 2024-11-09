using AuthService.API.Data;
using AuthService.API.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace AuthService.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _authDbContext;
        public UserRepository(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }
        public async Task AddUserAsync(User user)
        {
            _authDbContext.Users.AddAsync(user);
            await _authDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _authDbContext.Users.SingleOrDefaultAsync(u=>u.UserName == userName);
        }
    }
}
