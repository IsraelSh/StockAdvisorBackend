using StockAdvisorBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Services.Interfaces
{
    public interface IAdviceRequestService
    {
        Task<AdviceRequest> GetAdviceRequestByIdAsync(int id);
        Task<List<AdviceRequest>> GetAdviceRequestsByUserIdAsync(int userId);
        Task AddAdviceRequestAsync(AdviceRequest request);
    }
}
