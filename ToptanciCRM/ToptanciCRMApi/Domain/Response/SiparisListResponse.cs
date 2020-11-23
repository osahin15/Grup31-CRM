using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class SiparisListResponse:BaseResponse
    {
        public IEnumerable<Siparis> Siparisler { get; set; }
        private SiparisListResponse(bool success,string message,IEnumerable<Siparis> siparisler):base(success,message)
        {
            this.Siparisler = siparisler;
        }

        public SiparisListResponse(IEnumerable<Siparis> Siparis):this(true,string.Empty,Siparis)
        {
             
        }

        public SiparisListResponse(string message):this(false,message,null)
        {

        }

    }
}
