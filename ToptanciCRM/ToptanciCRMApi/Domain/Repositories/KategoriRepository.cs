using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public class KategoriRepository : BaseRepository, IKategoriRepository
    {

        public KategoriRepository(ToptanciCRMContext _context) : base(_context)
        {

        }
        public async Task<IEnumerable<Kategori>> GetKategori()
        {
            return await _context.Kategori.ToListAsync();

        }
        public async Task<Kategori> GetByIdAsync(int kategoriId)
        {
            return await _context.Kategori.FindAsync(kategoriId);
        }
        public async Task AddKategoriAsync(Kategori kategori)
        {
            await _context.Kategori.AddAsync(kategori);
        }     
        public async Task RemoveKategoriAsync(int kategoriId)
        {
            Kategori kategori = await GetByIdAsync(kategoriId);

            _context.Kategori.Remove(kategori);
        }
        public void UpdateKategoriAsync(Kategori kategori)
        {
            _context.Kategori.Update(kategori);
        }
    }
}
