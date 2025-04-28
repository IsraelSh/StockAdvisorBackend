using Microsoft.EntityFrameworkCore;
using StockAdvisorBackend.Data;
using StockAdvisorBackend.Models;
using StockAdvisorBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Implementations
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> GetStockByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<List<Stock>> GetAllStocksAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task AddStockAsync(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStockAsync(Stock stock)
        {
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStockAsync(Stock stock)
        {
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
        }
    }
}
