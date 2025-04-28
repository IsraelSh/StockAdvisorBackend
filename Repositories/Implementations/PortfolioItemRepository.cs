using Microsoft.EntityFrameworkCore;
using StockAdvisorBackend.Data;
using StockAdvisorBackend.Models;
using StockAdvisorBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Implementations
{
    public class PortfolioItemRepository : IPortfolioItemRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PortfolioItem>> GetPortfolioByUserIdAsync(int userId)
        {
            return await _context.PortfolioItems
                                 .Include(p => p.Stock)
                                 .Where(p => p.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<PortfolioItem> GetPortfolioItemAsync(int userId, int stockId)
        {
            return await _context.PortfolioItems
                                 .FirstOrDefaultAsync(p => p.UserId == userId && p.StockId == stockId);
        }

        public async Task AddPortfolioItemAsync(PortfolioItem item)
        {
            _context.PortfolioItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePortfolioItemAsync(PortfolioItem item)
        {
            _context.PortfolioItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemovePortfolioItemAsync(int userId, int stockId)
        {
            var item = await GetPortfolioItemAsync(userId, stockId);
            if (item != null)
            {
                _context.PortfolioItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
