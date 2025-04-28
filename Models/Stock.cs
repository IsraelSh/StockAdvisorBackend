namespace StockAdvisorBackend.Models
{
    public class Stock
    {
        public int Id { get; set; } 
        public string Symbol { get; set; } //// Example: "AAPL", "TSLA"
        public string CompanyName { get; set; } //// Example: "Apple Inc.", "Tesla Inc."
        public decimal CurrentPrice { get; set; }

        
    }
}
