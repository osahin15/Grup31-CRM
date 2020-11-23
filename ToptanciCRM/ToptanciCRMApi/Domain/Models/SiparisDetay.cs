using System;
using System.Collections.Generic;

namespace ToptanciCRMApi.Domain
{
    public partial class SiparisDetay
    {
        public int SiparisDetayId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public int SiparisId { get; set; }
    }
}
