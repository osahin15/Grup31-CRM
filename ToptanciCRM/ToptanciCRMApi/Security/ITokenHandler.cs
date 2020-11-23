using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;

namespace ToptanciCRMApi.Security
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(Kullanici kullanici);

        void RevokeRefreshToken(Kullanici kullanici);
    }

    
}
