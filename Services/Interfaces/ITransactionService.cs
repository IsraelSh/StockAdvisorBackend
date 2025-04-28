using StockAdvisorBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId);
        Task AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int id);

        Task<List<Transaction>> GetAllTransactionsAsync();
    }
}
