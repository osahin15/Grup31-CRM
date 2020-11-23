using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain.Response;
using ToptanciCRMApi.Domain.Services;
using ToptanciCRMApi.Security;

namespace ToptanciCRMApi.Serivices
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IUserService userService;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        public AccessTokenResponse CreateAccesToken(string email, string password)
        {
            UserResponse userResponse = userService.FindEmailAndPassword(email, password);

            if (userResponse.Success)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.user);
                userService.SaveRefreshToken(userResponse.user.KullaniciId, userResponse.user.RefreshToken);
                return new AccessTokenResponse(accessToken);
            }
            else
            {
                return new AccessTokenResponse(userResponse.Message);
            }

        }
        public AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken)
        {
            UserResponse userResponse = userService.GetUserWithToken(refreshToken);

            if (userResponse.Success)
            {
                if (userResponse.user.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken access = tokenHandler.CreateAccessToken(userResponse.user);

                    return new AccessTokenResponse(access);
                }
                else
                {
                    return new AccessTokenResponse("Access tokenın süresi dolmuş.");
                }
            }
            else
            {
                return new AccessTokenResponse("Refresh Token bulunamadı.");
            }

        }
        public AccessTokenResponse RevokeRefreshToken(string refreshToken)
        {
            UserResponse userResponse = userService.GetUserWithToken(refreshToken);

            if (userResponse.Success)
            {
                userService.RemoveRefreshToken(userResponse.user);
                return new AccessTokenResponse(new AccessToken());
            }
            else
            {
                return new AccessTokenResponse("refresh token bulunamdı.");
            }
        }
    }
}
