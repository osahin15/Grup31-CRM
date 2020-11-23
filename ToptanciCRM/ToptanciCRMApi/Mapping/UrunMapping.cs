using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Resource;

namespace ToptanciCRMApi.Mapping
{
    public class UrunMapping:Profile
    {
        public UrunMapping()
        {
            CreateMap<UrunResource, Urun>();
            CreateMap<Urun, UrunResource>();
        }
    }
}
