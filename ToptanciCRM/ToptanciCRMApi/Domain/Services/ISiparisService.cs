using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain.Response;

namespace ToptanciCRMApi.Domain.Services
{
    public interface ISiparisService
    {
        Task<SiparisListResponse> GetList();
        Task<SiparisResponse> GetById(int id);
        Task<SiparisResponse> AddSiparisAsync(Siparis siparis);
        Task<SiparisResponse> DeleteSiparisAsync(int id);
        Task<SiparisListResponse> GetByBayiIdSiparis(int bayiId);
    }
}
