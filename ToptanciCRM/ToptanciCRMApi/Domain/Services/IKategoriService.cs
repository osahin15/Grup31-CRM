using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain.Response;

namespace ToptanciCRMApi.Domain.Services
{
    public interface IKategoriService
    {
        Task<KategoriListResponse> ListAsync();
        Task<KategoriResponse> FindByIdAsync(int kategoriId);
        Task<KategoriResponse> AddKategoriAsync(Kategori kategori);
        Task<KategoriResponse> RemoveKategoriAsync(int kategoriId);
        Task<KategoriResponse> UpdateKategori(int kategoriId, Kategori kategori);
        

    }
}
