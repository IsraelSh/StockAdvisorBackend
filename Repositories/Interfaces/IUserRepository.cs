using StockAdvisorBackend.Models;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);

        Task<List<User>> GetAllUsersAsync();

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);



    }
}
