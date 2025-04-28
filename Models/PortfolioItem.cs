namespace StockAdvisorBackend.Models
{
    public class PortfolioItem /// Represents an item in a user's portfolio, which includes the stock and the quantity owned.
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StockId { get; set; }

        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; } // מחיר קניה ממוצע

        public User User { get; set; }
        public Stock Stock { get; set; }
    }
}
