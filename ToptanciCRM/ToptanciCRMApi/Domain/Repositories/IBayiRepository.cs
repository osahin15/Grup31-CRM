using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public interface IBayiRepository
    {
        Task AddBayiAsync(Bayi bayi);
        Task RemoveBayiAsync(int bayiId);
        void UpdateBayiAsync(Bayi bayi);
        Task<Bayi> FindByIdAsync(int bayiId);
        Task<IEnumerable<Bayi>> ListBayiAsync();
    }
}
