using System;
using System.Collections.Generic;

namespace ToptanciCRMApi.Domain
{
    public partial class Siparis
    {
        public int SiparisId { get; set; }
        public int BayiId { get; set; }
        public int ToptanciId { get; set; }        
        public DateTime? SiparisTarih { get; set; }
    }
}
