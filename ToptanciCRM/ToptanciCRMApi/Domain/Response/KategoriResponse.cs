using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class KategoriResponse:BaseResponse
    {
        public Kategori Kategori { get; set; }
        private KategoriResponse(bool success, string message, Kategori kategori) : base(success, message)
        {
            this.Kategori = kategori;
        }
        //if do success
        public KategoriResponse(Kategori kategori) : this(true, string.Empty, kategori)
        {

        }

        //if do fail
        public KategoriResponse(string message) : this(false, message, null)
        {

        }

    }
}
