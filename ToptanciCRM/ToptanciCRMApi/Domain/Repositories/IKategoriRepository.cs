using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public interface IKategoriRepository
    {
        Task<IEnumerable<Kategori>> GetKategori();
        Task<Kategori> GetByIdAsync(int kategoriId);
        Task AddKategoriAsync(Kategori kategori);
        Task RemoveKategoriAsync(int kategoriId);
        void UpdateKategoriAsync(Kategori kategori);
        


    }
}
