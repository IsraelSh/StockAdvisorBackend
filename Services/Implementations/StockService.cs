using StockAdvisorBackend.Models;
using StockAdvisorBackend.Repositories.Interfaces;
using StockAdvisorBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Stock> GetStockByIdAsync(int id)
        {
            return await _stockRepository.GetStockByIdAsync(id);
        }

        public async Task<List<Stock>> GetAllStocksAsync()
        {
            return await _stockRepository.GetAllStocksAsync();
        }

        public async Task AddStockAsync(Stock stock)
        {
            await _stockRepository.AddStockAsync(stock);
        }

        public async Task UpdateStockAsync(Stock stock)
        {
            await _stockRepository.UpdateStockAsync(stock);
        }

        public async Task DeleteStockAsync(Stock stock)
        {
            await _stockRepository.DeleteStockAsync(stock);
        }
    }
}
