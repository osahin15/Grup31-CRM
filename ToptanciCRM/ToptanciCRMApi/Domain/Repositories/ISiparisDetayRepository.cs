using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public interface ISiparisDetayRepository
    {
        Task<IEnumerable<SiparisDetay>> GetSiparisDetay();
        Task<SiparisDetay> GetByIdAsync(int siparisDetayId);
        Task AddSiparisDetayAsync(SiparisDetay kategori);
        Task RemoveSiparisDetayAsync(int siparisDetayId);
        void UpdateSiparisDetayAsync(SiparisDetay kategori);
        Task<IEnumerable<SiparisDetay>> GetSiparisDetayWithSiparisId(int siparisId);
    }
}
