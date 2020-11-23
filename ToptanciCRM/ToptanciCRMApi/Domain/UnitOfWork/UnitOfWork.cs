using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToptanciCRMContext _context;
        public UnitOfWork(ToptanciCRMContext context)
        {

            _context = context;

        }
        public void CompleteAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
