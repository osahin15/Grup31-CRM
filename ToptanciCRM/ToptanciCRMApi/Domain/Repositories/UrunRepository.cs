using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public class UrunRepository : BaseRepository, IUrunRepository
    {

        public UrunRepository(ToptanciCRMContext _contex) : base(_contex)
        {

        }
        public async Task<IEnumerable<Urun>> GetList()
        {
            return await _context.Urun.ToListAsync();
        }
        public async Task<Urun> GetByIdUrun(int id)
        {
            return await _context.Urun.FindAsync(id);
        }
        public async Task AddUrunAsync(Urun urun)
        {
            await _context.Urun.AddAsync(urun);
        }
        public async Task Delete(int id)
        {
            var Urun = await GetByIdUrun(id);
            _context.Urun.Remove(Urun);
        }
        public void Update(Urun urun)
        {
            _context.Urun.Update(urun);
        }

    }
}
