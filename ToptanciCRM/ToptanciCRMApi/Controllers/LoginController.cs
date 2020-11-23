using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToptanciCRMApi.Domain.Response;
using ToptanciCRMApi.Domain.Services;
using ToptanciCRMApi.Extencions;
using ToptanciCRMApi.Resource;

namespace ToptanciCRMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                AccessTokenResponse accessTokenResponse = authenticationService.CreateAccesToken(loginResource.Email, loginResource.Password);

                if (accessTokenResponse.Success)
                {
                    return Ok(accessTokenResponse.accessToken);
                }
                else
                {
                    return BadRequest(accessTokenResponse.Message);
                }

            }
        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {
            AccessTokenResponse accessTokenResponse = authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.Success);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            }


        }

        [HttpPost]
        public IActionResult RemoveRefreshToken(TokenResource tokenResource)
        {
            AccessTokenResponse accessTokenResponse = authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.accessToken);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            }
        }

    }
}
