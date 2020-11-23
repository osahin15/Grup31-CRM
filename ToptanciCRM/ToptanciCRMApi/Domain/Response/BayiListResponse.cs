using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class BayiListResponse:BaseResponse
    {

        public IEnumerable<Bayi> Bayiler { get; set; }

        private BayiListResponse(bool success, string message, IEnumerable<Bayi> Bayi) : base(success, message)
        {
            this.Bayiler = Bayi;
        }


        //başarılı olurşa
        public BayiListResponse(IEnumerable<Bayi> bayiler) : this(true, string.Empty, bayiler)
        {

        }

        //başarısız olursa 
        public BayiListResponse(string message) : this(false, message, null)
        {

        }

    }
}
