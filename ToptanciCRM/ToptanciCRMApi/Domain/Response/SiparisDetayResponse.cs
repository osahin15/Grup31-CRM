using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class SiparisDetayResponse:BaseResponse
    {
        public SiparisDetay SiparisDetay { get; set; }
        private SiparisDetayResponse(bool success,string message,SiparisDetay siparisDetay):base(success,message)
        {
            this.SiparisDetay = siparisDetay;
        }

        public SiparisDetayResponse(SiparisDetay siparisDetay):this(true,string.Empty,siparisDetay)
        {

        }

        public SiparisDetayResponse(string message):this(false,message,null)
        {

        }
    
    
    
    }


}
