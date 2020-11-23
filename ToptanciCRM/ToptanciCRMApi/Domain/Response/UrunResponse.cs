using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class UrunResponse:BaseResponse
    {
        public Urun Urun { get; set; }
        private UrunResponse(bool succes,string message,Urun urun):base(succes,message)
        {
            this.Urun=urun;
        }

        public UrunResponse(Urun urun):this(true,string.Empty,urun)
        {
        }

        public UrunResponse(string message) : this(false, message, null)
        {

        }
    }
}
