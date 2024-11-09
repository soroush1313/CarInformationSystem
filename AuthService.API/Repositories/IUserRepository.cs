using AuthService.API.Entities;

namespace AuthService.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAsync(string userName);
        Task AddUserAsync(User user);
    }
}
