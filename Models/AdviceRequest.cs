namespace StockAdvisorBackend.Models
{
    public class AdviceRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
    }
}
