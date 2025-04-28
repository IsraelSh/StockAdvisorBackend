using StockAdvisorBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Services.Interfaces
{
    public interface IStockService
    {
        Task<Stock> GetStockByIdAsync(int id);
        Task<List<Stock>> GetAllStocksAsync();
        Task AddStockAsync(Stock stock);
        Task UpdateStockAsync(Stock stock);
        Task DeleteStockAsync(Stock stock); 
    }
}
