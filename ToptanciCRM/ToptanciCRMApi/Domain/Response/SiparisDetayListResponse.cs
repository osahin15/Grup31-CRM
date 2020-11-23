using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class SiparisDetayListResponse:BaseResponse
    {
        public IEnumerable<SiparisDetay> SiparisDetayListe { get; set; }
        private SiparisDetayListResponse(bool success,string message, IEnumerable<SiparisDetay> SiparisDetayListe):base(success,message)
        {
            this.SiparisDetayListe = SiparisDetayListe;
        }

        public SiparisDetayListResponse(IEnumerable<SiparisDetay> siparisDetayListe):this(true,string.Empty,siparisDetayListe)
        {

        }

        public SiparisDetayListResponse(string message) : this(false,message,null)
        {

        }
    }
}
