using System.Transactions;

namespace StockAdvisorBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public List<PortfolioItem> Portfolio { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
