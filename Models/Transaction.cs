namespace StockAdvisorBackend.Models
{
    public class Transaction /// Represents a transaction made by a user, either a purchase or a sale of a stock.
        //כל פעולה של קנייה/מכירה נרשמת פה – קריטי בשביל Event Sourcing וגרפים.
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StockId { get; set; }

        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTransaction { get; set; }
        public bool IsPurchase { get; set; } // true = קניה, false = מכירה

        public User User { get; set; }
        public Stock Stock { get; set; }

        public string TransactionType { get; set; } // "Buy" or "Sell"
    }
}
