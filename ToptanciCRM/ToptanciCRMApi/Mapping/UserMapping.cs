using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Domain.Response;

namespace ToptanciCRMApi.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<UserResponse, Kullanici>();
            CreateMap<Kullanici, UserResponse>();
        }
    }
}
