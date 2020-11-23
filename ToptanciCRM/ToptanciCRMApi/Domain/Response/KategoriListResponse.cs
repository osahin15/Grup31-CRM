using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class KategoriListResponse:BaseResponse
    {
        public IEnumerable<Kategori> Kategoriler { get; set; }

        private KategoriListResponse(bool success, string message, IEnumerable<Kategori> kategoriler) : base(success, message)
        {
            this.Kategoriler = kategoriler;
        }

        //başarılı olurşa
        public KategoriListResponse(IEnumerable<Kategori> kategoriler) : this(true, string.Empty, kategoriler)
        {
        
        }

        //başarısız olursa 
        public KategoriListResponse(string message) : this(false, message, null)
        {

        }
    }
}
