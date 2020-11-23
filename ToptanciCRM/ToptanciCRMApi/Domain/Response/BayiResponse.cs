using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class BayiResponse:BaseResponse
    {
        public Bayi Bayi { get; set; }

        private BayiResponse(bool success, string message, Bayi Bayi) : base(success, message)
        {
            this.Bayi = Bayi;
        }
        //başarılı olurşa
        public BayiResponse(Bayi bayi) : this(true, string.Empty, bayi)
        {

        }

        //başarısız olursa 
        public BayiResponse(string message) : this(false, message, null)
        {

        }
    }
}
