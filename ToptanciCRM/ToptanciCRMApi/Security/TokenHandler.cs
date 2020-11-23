using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;

namespace ToptanciCRMApi.Security
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions tokenOptions;

        public TokenHandler(IOptions<TokenOptions> tokenOptions)
        {
            this.tokenOptions = tokenOptions.Value;
        }

        public AccessToken CreateAccessToken(Kullanici kullanici)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);

            var securityKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaim(kullanici),
                signingCredentials: signingCredentials

                );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            AccessToken accessToken = new AccessToken();

            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accessTokenExpiration;

            return accessToken;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);

                return Convert.ToBase64String(numberByte);
            }
        }

        private IEnumerable<Claim> GetClaim(Kullanici kullanici)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,kullanici.KullaniciId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,kullanici.Email),
                new Claim(ClaimTypes.Name,$"{kullanici.Ad} {kullanici.Soyad}"),
                new  Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            return claims;
        }

        public void RevokeRefreshToken(Kullanici kullanici)
        {
            kullanici.RefreshToken = null;
        }
    }
}
