using StockAdvisorBackend.Models;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);



    }
}
