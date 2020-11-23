using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain.Response;

namespace ToptanciCRMApi.Domain.Services
{
    public interface IAuthenticationService
    {
        AccessTokenResponse CreateAccesToken(string email, string password);
        AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken);
        AccessTokenResponse RevokeRefreshToken(string refreshToken);
    }
}
