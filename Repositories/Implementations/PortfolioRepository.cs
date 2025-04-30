using Microsoft.EntityFrameworkCore;
using StockAdvisorBackend.Data;
using StockAdvisorBackend.Models;
using StockAdvisorBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Implementations
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PortfolioModel>> GetPortfolioByUserIdAsync(int userId)
        {
            return await _context.PortfolioItems
                                 .Include(p => p.Stock)
                                 .Where(p => p.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<PortfolioModel> GetPortfolioItemAsync(int userId, int stockId)
        {
            return await _context.PortfolioItems
                                 .FirstOrDefaultAsync(p => p.UserId == userId && p.StockId == stockId);
        }

        public async Task AddPortfolioItemAsync(PortfolioModel item)
        {
            _context.PortfolioItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePortfolioItemAsync(PortfolioModel item)
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
