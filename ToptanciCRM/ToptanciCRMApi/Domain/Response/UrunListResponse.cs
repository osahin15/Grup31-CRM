using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class UrunListResponse:BaseResponse
    {
        public IEnumerable<Urun> Uruns;
        public UrunListResponse(bool succes, string message, IEnumerable<Urun> urunler) : base(succes, message)
        {
            this.Uruns = urunler;
        }

        //if do succes

        public UrunListResponse(IEnumerable<Urun> uruns):this(true,string.Empty,uruns)
        {
            
        }

        public UrunListResponse(string message):this(false,string.Empty,null)
        {

        }



    }
}
