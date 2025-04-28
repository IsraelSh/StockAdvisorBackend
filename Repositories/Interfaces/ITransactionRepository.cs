using StockAdvisorBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId);
        Task AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id); // פונקציה לחיפוש עסקה לפי ID
        Task UpdateTransactionAsync(Transaction transaction); // פונקציה לעדכון עסקה
        Task DeleteTransactionAsync(int id); // פונקציה למחיקת עסקה

        Task<List<Transaction>> GetAllTransactionsAsync();
    }
}
