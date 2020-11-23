using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public class SiparisDetayRepository:BaseRepository,ISiparisDetayRepository
    {
        public SiparisDetayRepository(ToptanciCRMContext _context):base(_context)
        {

        }
        public async Task<IEnumerable<SiparisDetay>> GetSiparisDetay()
        {
            return await _context.SiparisDetay.ToListAsync();
        }
        public async Task<SiparisDetay> GetByIdAsync(int siparisDetayId)
        {
            return await _context.SiparisDetay.FindAsync(siparisDetayId);
        }
        public async Task<IEnumerable<SiparisDetay>> GetSiparisDetayWithSiparisId(int siparisId)
        {
            return await _context.SiparisDetay.Where(p => p.SiparisId == siparisId).ToListAsync();
        }
        public async Task AddSiparisDetayAsync(SiparisDetay siparisDetay)
        {
            await _context.SiparisDetay.AddAsync(siparisDetay);
        }       
        public async Task RemoveSiparisDetayAsync(int siparisDetayId)
        {
            SiparisDetay siparisDetay = await GetByIdAsync(siparisDetayId);
            _context.SiparisDetay.Remove(siparisDetay);
        }
        public void UpdateSiparisDetayAsync(SiparisDetay siparisDetay)
        {
            _context.SiparisDetay.Update(siparisDetay);
        }

    }
}
