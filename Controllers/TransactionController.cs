using Microsoft.AspNetCore.Mvc;
using StockAdvisorBackend.DTOs;
using StockAdvisorBackend.Models;
using StockAdvisorBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // קבלת כל העסקאות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        // קבלת עסקה לפי ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionModel>> GetTransactionById(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound("Transaction not found.");
            return Ok(transaction);
        }

        // הוספת עסקה חדשה
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionDto request)
        {
            var transaction = new TransactionModel
            {
                UserId = request.UserId,
                StockId = request.StockId,
                TransactionAmount = request.TransactionAmount,
                PriceAtTransaction = request.PriceAtTransaction,
                TransactionType = request.TransactionType,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionService.AddTransactionAsync(transaction);

            return Ok("Transaction created successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] TransactionDto request)
        {
            var existingTransaction = await _transactionService.GetTransactionByIdAsync(id);

            if (existingTransaction == null)
                return NotFound("Transaction not found.");

            existingTransaction.UserId = request.UserId;
            existingTransaction.StockId = request.StockId;
            existingTransaction.TransactionAmount = request.TransactionAmount;
            existingTransaction.PriceAtTransaction = request.PriceAtTransaction;
            existingTransaction.TransactionType = request.TransactionType;

            await _transactionService.UpdateTransactionAsync(existingTransaction);

            return Ok("Transaction updated successfully!");
        }
    

        // מחיקת עסקה
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound("Transaction not found.");

            await _transactionService.DeleteTransactionAsync(id);
            return Ok("Transaction deleted successfully!");
        }
    }
}
