using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain.Response;

namespace ToptanciCRMApi.Domain.Services
{
    public interface IUrunService
    {
        Task<UrunListResponse> GetList();
        Task<UrunResponse> GetById(int id );
        Task<UrunResponse> AddUrunAsync(Urun urun);
        Task<UrunResponse> DeleteAsync(int id );
        Task<UrunResponse> UpdateAsync(Urun urun,int id);


    }
}
