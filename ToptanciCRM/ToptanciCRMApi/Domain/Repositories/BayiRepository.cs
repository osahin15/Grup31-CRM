using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public class BayiRepository : BaseRepository,IBayiRepository
    {
        public BayiRepository(ToptanciCRMContext _context):base(_context)
        {

        }
        
        public async Task AddBayiAsync(Bayi bayi)
        {
            await _context.Bayi.AddAsync(bayi);
        }

        public async Task<Bayi> FindByIdAsync(int bayiId)
        {
            return await _context.Bayi.FindAsync(bayiId);
        }

        public async Task<IEnumerable<Bayi>> ListBayiAsync()
        {
            return await _context.Bayi.ToListAsync();
        }

        public async Task RemoveBayiAsync(int bayiId)
        {
            var bayi = await FindByIdAsync(bayiId);

            _context.Bayi.Remove(bayi);
        }

        public void UpdateBayiAsync(Bayi bayi)
        {
           _context.Bayi.Update(bayi);
        }
    }
}
