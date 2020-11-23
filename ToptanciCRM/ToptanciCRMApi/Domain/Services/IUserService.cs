using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain.Response;

namespace ToptanciCRMApi.Domain.Services
{
    public interface IUserService
    {
        UserResponse AddUser(Kullanici user);
        UserResponse FindById(int userId);
        UserResponse FindEmailAndPassword(string email, string password);
        void SaveRefreshToken(int userId, string RefreshToken);
        UserResponse GetUserWithToken(string RefreshToken);
        void RemoveRefreshToken(Kullanici user);
    }
}
