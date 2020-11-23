using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public interface IUrunRepository
    {
        Task<IEnumerable<Urun>> GetList();
        Task<Urun> GetByIdUrun(int id);
        Task AddUrunAsync(Urun urun);
        Task Delete(int id);
        void Update(Urun urun);
    }
}
