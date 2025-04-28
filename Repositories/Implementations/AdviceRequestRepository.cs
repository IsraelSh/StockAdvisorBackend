using Microsoft.EntityFrameworkCore;
using StockAdvisorBackend.Data;
using StockAdvisorBackend.Models;
using StockAdvisorBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Implementations
{
    public class AdviceRequestRepository : IAdviceRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public AdviceRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdviceRequest> GetAdviceRequestByIdAsync(int id)
        {
            return await _context.AdviceRequests.FindAsync(id);
        }

        public async Task<List<AdviceRequest>> GetAdviceRequestsByUserIdAsync(int userId)
        {
            return await _context.AdviceRequests
                                 .Where(a => a.UserId == userId)
                                 .ToListAsync();
        }

        public async Task AddAdviceRequestAsync(AdviceRequest request)
        {
            _context.AdviceRequests.Add(request);
            await _context.SaveChangesAsync();
        }
    }
}
