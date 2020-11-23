using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly ToptanciCRMContext _context;

        public BaseRepository(ToptanciCRMContext context)
        {
            _context = context;
        }
    }
}
