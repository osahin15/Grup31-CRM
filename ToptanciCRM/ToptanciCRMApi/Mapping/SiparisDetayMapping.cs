using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Resource;

namespace ToptanciCRMApi.Mapping
{
    public class SiparisDetayMapping : Profile
    {
        public SiparisDetayMapping()
        {
            CreateMap<SiparisDetayResource, SiparisDetay>();
            CreateMap<SiparisDetay, SiparisDetayResource>();
        }
    }
}
