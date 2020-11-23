using System;
using System.Collections.Generic;

namespace ToptanciCRMApi.Domain
{
    public partial class Kullanici
    {
        public int KullaniciId { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
