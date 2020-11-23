using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Resource;

namespace ToptanciCRMApi.Mapping
{
    public class BayiMapping:Profile
    {
        public BayiMapping()
        {
            CreateMap<BayiResource, Bayi>();
            CreateMap<Bayi, BayiResource>();
        }
    }
}
