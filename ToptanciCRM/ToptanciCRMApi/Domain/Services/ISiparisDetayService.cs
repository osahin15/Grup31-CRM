using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain.Response;

namespace ToptanciCRMApi.Domain.Services
{
    public interface ISiparisDetayService
    {
        Task<SiparisDetayListResponse> ListAsync();
        Task<SiparisDetayResponse> FindByIdAsync(int id );
        Task<SiparisDetayListResponse> ListBySiparisIdAsync(int id);
        Task<SiparisDetayResponse> AddSiparisDetayAsync(SiparisDetay siparisDetay);
        Task<SiparisDetayResponse> RemoveSiparisDetayAsync(int id);
        Task<SiparisDetayResponse> UpdateSiparisDetayAsync(int siparisDetayId, SiparisDetay siparisDetay);

    }
}
