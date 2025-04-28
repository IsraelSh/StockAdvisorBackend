using StockAdvisorBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Interfaces
{
    public interface IPortfolioItemRepository
    {
        Task<List<PortfolioItem>> GetPortfolioByUserIdAsync(int userId);
        Task<PortfolioItem> GetPortfolioItemAsync(int userId, int stockId);
        Task AddPortfolioItemAsync(PortfolioItem item);
        Task UpdatePortfolioItemAsync(PortfolioItem item);
        Task RemovePortfolioItemAsync(int userId, int stockId);
    }
}
