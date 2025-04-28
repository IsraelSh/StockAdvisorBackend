using StockAdvisorBackend.Models;
using StockAdvisorBackend.Repositories.Interfaces;
using StockAdvisorBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioItemRepository _portfolioItemRepository;

        public PortfolioService(IPortfolioItemRepository portfolioItemRepository)
        {
            _portfolioItemRepository = portfolioItemRepository;
        }

        public async Task<List<PortfolioItem>> GetPortfolioByUserIdAsync(int userId) // לשלוף את כל התיק של משתמש.
        {
            return await _portfolioItemRepository.GetPortfolioByUserIdAsync(userId);
        }

        public async Task<PortfolioItem> GetPortfolioItemAsync(int userId, int stockId) // לשלוף פריט תיק מסוים של משתמש.לשלוף פריט ספציפי בתיק (לפי StockId).
        {
            return await _portfolioItemRepository.GetPortfolioItemAsync(userId, stockId);
        }

        public async Task AddPortfolioItemAsync(PortfolioItem item) // להוסיף מניה   למשתמש.
        {
            await _portfolioItemRepository.AddPortfolioItemAsync(item);
        }

        public async Task UpdatePortfolioItemAsync(PortfolioItem item) // לעדכן מניה בתיק (למשל להגדיל כמות).
        {
            await _portfolioItemRepository.UpdatePortfolioItemAsync(item);
        }

        public async Task RemovePortfolioItemAsync(int userId, int stockId) // למחוק מניה מהתיק.
        {
            await _portfolioItemRepository.RemovePortfolioItemAsync(userId, stockId);
        }
    }
}
