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
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        // קבלת עסקה לפי ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound("Transaction not found.");
            return Ok(transaction);
        }

        // הוספת עסקה חדשה
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] CreateTransactionDto request)
        {
            var transaction = new Transaction
            {
                UserId = request.UserId,
                StockId = request.StockId,
                Quantity = request.Quantity,
                PriceAtTransaction = request.PriceAtTransaction,
                TransactionType = request.TransactionType
            };

            await _transactionService.AddTransactionAsync(transaction);

            return Ok("Transaction created successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] CreateTransactionDto request)
        {
            var existingTransaction = await _transactionService.GetTransactionByIdAsync(id);

            if (existingTransaction == null)
                return NotFound("Transaction not found.");

            existingTransaction.UserId = request.UserId;
            existingTransaction.StockId = request.StockId;
            existingTransaction.Quantity = request.Quantity;
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
