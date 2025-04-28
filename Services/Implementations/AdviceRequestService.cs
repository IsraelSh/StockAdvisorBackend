using StockAdvisorBackend.Models;
using StockAdvisorBackend.Repositories.Interfaces;
using StockAdvisorBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAdvisorBackend.Services.Implementations
{
    public class AdviceRequestService : IAdviceRequestService
    {
        private readonly IAdviceRequestRepository _adviceRequestRepository;

        public AdviceRequestService(IAdviceRequestRepository adviceRequestRepository)
        {
            _adviceRequestRepository = adviceRequestRepository;
        }

        public async Task<AdviceRequest> GetAdviceRequestByIdAsync(int id)
        {
            return await _adviceRequestRepository.GetAdviceRequestByIdAsync(id);
        }

        public async Task<List<AdviceRequest>> GetAdviceRequestsByUserIdAsync(int userId)
        {
            return await _adviceRequestRepository.GetAdviceRequestsByUserIdAsync(userId);
        }

        public async Task AddAdviceRequestAsync(AdviceRequest request)
        {
            await _adviceRequestRepository.AddAdviceRequestAsync(request);
        }
    }
}
