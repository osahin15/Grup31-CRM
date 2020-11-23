using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class SiparisResponse:BaseResponse
    {
        public Siparis Siparis { get; set; }
        public SiparisResponse(bool success, string message, Siparis siparis) : base(success,message)
        {
            this.Siparis = siparis;
        }

        public SiparisResponse(Siparis siparis):this(true,string.Empty,siparis)
        {

        }

        public SiparisResponse(string message):this(false,message,null)
        {

        }
    }
}
