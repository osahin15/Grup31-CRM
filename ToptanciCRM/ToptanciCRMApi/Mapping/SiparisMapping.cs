using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Resource;

namespace ToptanciCRMApi.Mapping
{
    public class SiparisMapping:Profile
    {
        public SiparisMapping()
        {
            CreateMap<Siparis, SiparisResource>();
            CreateMap<SiparisResource, Siparis>();
        }
    }
}
