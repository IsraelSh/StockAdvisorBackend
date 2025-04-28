using Microsoft.AspNetCore.Mvc;
using StockAdvisorBackend.DTOs;
using StockAdvisorBackend.Models;
using StockAdvisorBackend.Services.Interfaces;
using System.Threading.Tasks;


namespace StockAdvisorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        // 🎯 הוספת מניה לתיק האישי
        [HttpPost]
        public async Task<IActionResult> AddPortfolioItem([FromBody] CreatePortfolioItemDto request)
        {
            var portfolioItem = new PortfolioItem
            {
                UserId = request.UserId,
                StockId = request.StockId,
                Quantity = request.Quantity,
                PurchasePrice = request.PurchasePrice
            };

            await _portfolioService.AddPortfolioItemAsync(portfolioItem);

            return Ok("Stock added to portfolio successfully.");
        }

        // 🎯 שליפת כל המניות בתיק של משתמש
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPortfolioByUserId(int userId)
        {
            var portfolio = await _portfolioService.GetPortfolioByUserIdAsync(userId);

            if (portfolio == null || portfolio.Count == 0)
                return NotFound("No portfolio items found for this user.");

            return Ok(portfolio);
        }
    }
}
