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

        public async Task<StockModel> GetStockByIdAsync(int id)
        {
            return await _stockRepository.GetStockByIdAsync(id);
        }

        public async Task<List<StockModel>> GetAllStocksAsync()
        {
            return await _stockRepository.GetAllStocksAsync();
        }

        public async Task AddStockAsync(StockModel stock)
        {
            await _stockRepository.AddStockAsync(stock);
        }

        public async Task UpdateStockAsync(StockModel stock)
        {
            await _stockRepository.UpdateStockAsync(stock);
        }

        public async Task DeleteStockAsync(StockModel stock)
        {
            await _stockRepository.DeleteStockAsync(stock);
        }

        public async Task<StockModel> GetStockBySymbolAsync(string symbol)
        {
            return await _stockRepository.GetStockBySymbolAsync(symbol);
        }

    }
}
