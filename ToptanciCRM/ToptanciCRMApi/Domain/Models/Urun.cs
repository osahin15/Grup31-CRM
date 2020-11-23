using System;
using System.Collections.Generic;

namespace ToptanciCRMApi.Domain
{
    public partial class Urun
    {
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public int? UrunFiyat { get; set; }
        public int? KategoriId { get; set; }
    }
}
