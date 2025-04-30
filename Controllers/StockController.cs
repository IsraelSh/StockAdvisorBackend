using Microsoft.AspNetCore.Mvc;
using StockAdvisorBackend.Models;
using StockAdvisorBackend.Services.Interfaces;
using StockAdvisorBackend.DTOs; // בשביל CreateStockDto

namespace StockAdvisorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            var stock = await _stockService.GetStockByIdAsync(id);
            if (stock == null)
                return NotFound("Stock not found.");
            return Ok(stock);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _stockService.GetAllStocksAsync();
            return Ok(stocks);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] StockDto request)
        {
            var stock = new StockModel
            {
                Symbol = request.Symbol,
              //  CompanyName = request.CompanyName,
                CurrentPrice = request.CurrentPrice
            };

            await _stockService.AddStockAsync(stock);
            return Ok("Stock added successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] StockDto request)
        {
            var stock = new StockModel
            {
                Id = id,
                Symbol = request.Symbol,
             //   CompanyName = request.CompanyName,
                CurrentPrice = request.CurrentPrice
            };

            await _stockService.UpdateStockAsync(stock);
            return Ok("Stock updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _stockService.GetStockByIdAsync(id);

            if (stock == null)
                return NotFound("Stock not found.");

            await _stockService.DeleteStockAsync(stock);
            return Ok("Stock deleted successfully!");
        }

    }
}
