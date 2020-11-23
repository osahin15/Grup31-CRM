using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Resource;

namespace ToptanciCRMApi.Mapping
{
    public class KategoriMapping:Profile
    {
        public KategoriMapping()
        {
            CreateMap<KategoriResource, Kategori>();
            CreateMap<Kategori, KategoriResource>();

        }
    }
}
