using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Resource
{
    public class BayiResource
    {
        [Required]
        public string BayiAd { get; set; }
        [Required]
        public string BayiMail { get; set; }
        [Required]
        public string BayiAdres { get; set; }
    }
}
