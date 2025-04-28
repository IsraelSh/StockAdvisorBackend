using StockAdvisorBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Repositories.Interfaces
{
    public interface IAdviceRequestRepository
    {
        Task<AdviceRequest> GetAdviceRequestByIdAsync(int id);
        Task<List<AdviceRequest>> GetAdviceRequestsByUserIdAsync(int userId);
        Task AddAdviceRequestAsync(AdviceRequest request);
    }
}
