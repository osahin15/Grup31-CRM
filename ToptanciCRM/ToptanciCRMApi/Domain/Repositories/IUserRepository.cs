using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Repositories
{
    public interface IUserRepository
    {
        void AddUser(Kullanici user);

        Kullanici FindById(int userId);

        Kullanici FindByEmailandPassword(string email, string password);

        void SaveRefreshToken(int userId, string refreshToken);

        Kullanici GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(Kullanici user); 
    }
}
