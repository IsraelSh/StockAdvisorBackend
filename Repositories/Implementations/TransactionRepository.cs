using Microsoft.EntityFrameworkCore;
using StockAdvisorBackend.Data;
using StockAdvisorBackend.Models;
using StockAdvisorBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // קבלת כל העסקאות של המשתמש
        public async Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId)
        {
            return await _context.Transactions
                                 .Include(t => t.Stock) // אם ברצונך להוסיף מידע על המניה
                                 .Where(t => t.UserId == userId)
                                 .ToListAsync();
        }

        // הוספת עסקה חדשה
        public async Task AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        // קבלת עסקה לפי ID
        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions
                                 .Include(t => t.Stock) // כולל את המניה כדי שנוכל להחזיר אותה
                                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        // עדכון עסקה
        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        // מחיקת עסקה
        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Transaction>> GetAllTransactionsAsync()  // הוספנו את הפונקציה הזאת
        {
            return await _context.Transactions
                                 .Include(t => t.Stock)
                                 .ToListAsync();
        }
    }
}
