using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain.Response;

namespace ToptanciCRMApi.Domain.Services
{
    public interface IBayiService
    {
        Task<BayiListResponse> ListAsyc();
        Task<BayiResponse> FindByIdAsync(int bayiId);
        Task<BayiResponse> AddBayiAsync(Bayi bayi);        
        Task<BayiResponse> UpdateBayiAsync(Bayi bayi, int bayiId);
        Task<BayiResponse> RemoveBayiAsync(int bayiId);
        

    }
}
