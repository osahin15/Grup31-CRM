using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public class SiparisRepository:BaseRepository,ISiparisRepository
    {

        public SiparisRepository(ToptanciCRMContext _context):base(_context)
        {

        }

        public async Task AddSiparisAsync(Siparis siparis)
        {
            await _context.Siparis.AddAsync(siparis);
        }       
        public async Task<IEnumerable<Siparis>> GetByBayiIdSiparis(int bayiId)
        {
            return await _context.Siparis.Where(p => p.BayiId == bayiId).ToListAsync();
        }
        public async Task<Siparis> GetByIdAsync(int siparisId)
        {
            return await _context.Siparis.FindAsync(siparisId);
        }
        public async Task<IEnumerable<Siparis>> GetSiparisAsync()
        {
            return await _context.Siparis.ToListAsync();
        }
        public async Task RemoveSiparisAsync(int siparisId)
        {
            Siparis siparis =  await GetByIdAsync(siparisId);
            _context.Siparis.Remove(siparis);
        }


    }
}
