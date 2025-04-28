using Microsoft.EntityFrameworkCore;
using StockAdvisorBackend.Models;
using System.Collections.Generic;


//It tells Entity Framework (ORM library) which tables are in the system.

////Each DbSet<T> is a table.

////It will also manage all connections to Somee 


namespace StockAdvisorBackend.Data // Data access layer
{
    public class ApplicationDbContext : DbContext // This class represents the database context for the application.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // טבלאות במערכת
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AdviceRequest> AdviceRequests { get; set; } // אם החלטת להוסיף גם ייעוץ
    }
}
