using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public interface ISiparisRepository
    {
        Task<IEnumerable<Siparis>> GetSiparisAsync();
        Task<Siparis> GetByIdAsync(int siparisId);
        Task AddSiparisAsync(Siparis siparis);
        Task RemoveSiparisAsync(int siparisId);
        Task<IEnumerable<Siparis>> GetByBayiIdSiparis(int bayiId);      

    }
}
