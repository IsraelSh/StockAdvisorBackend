using StockAdvisorBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


//A Repository is a file that contains functions that talk to the database: saving, retrieving, updating, and deleting objects from the DB.
// It is a design pattern that separates the logic that retrieves data from the underlying storage system.
namespace StockAdvisorBackend.Repositories.Interfaces
{
    public interface IStockRepository // Interface for stock repository

        /// This interface defines the contract for stock-related data operations.
    {
        Task<Stock> GetStockByIdAsync(int id);
        Task<List<Stock>> GetAllStocksAsync();
        Task AddStockAsync(Stock stock);
        Task UpdateStockAsync(Stock stock);
        Task DeleteStockAsync(Stock stock);
    }
}
