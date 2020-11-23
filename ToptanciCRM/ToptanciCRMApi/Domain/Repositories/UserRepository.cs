using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Security;

namespace ToptanciCRMApi.Domain.Repositories
{
    public class UserRepository:BaseRepository,IUserRepository
    {
        private readonly TokenOptions tokenOptions;

        public UserRepository(ToptanciCRMContext context, IOptions<TokenOptions> tokenOptions) : base(context)
        {
            this.tokenOptions = tokenOptions.Value;
        }

        public void AddUser(Kullanici user)
        {
            _context.Kullanici.Add(user);
        }

        public Kullanici FindByEmailandPassword(string email, string password)
        {
            return _context.Kullanici.Where(p => p.Email == email && p.Sifre == password).FirstOrDefault();
        }

        public Kullanici FindById(int userId)
        {
            return _context.Kullanici.Find(userId);
        }

        public Kullanici GetUserWithRefreshToken(string refreshToken)
        {
            return _context.Kullanici.FirstOrDefault(p => p.RefreshToken == refreshToken);
        }

        public void RemoveRefreshToken(Kullanici user)
        {
            Kullanici newUser = this.FindById(user.KullaniciId);
            newUser.RefreshToken = null;
            newUser.RefreshTokenEndDate = null;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            Kullanici newUser = this.FindById(userId);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration);
        }

    }
}
