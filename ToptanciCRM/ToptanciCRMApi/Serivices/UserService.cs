using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Domain.Repositories;
using ToptanciCRMApi.Domain.Response;
using ToptanciCRMApi.Domain.Services;
using ToptanciCRMApi.Domain.UnitOfWork;

namespace ToptanciCRMApi.Serivices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;

        }

        public UserResponse AddUser(Kullanici user)
        {

            try
            {
                userRepository.AddUser(user);
                unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı eklenirken bir hata meydana geldi: {ex.Message}");

            }
        }

        public UserResponse FindById(int userId)
        {
            try
            {
                Kullanici user = userRepository.FindById(userId);
                if (user == null)
                {
                    return new UserResponse("Kullanıcı bulunamadı");
                }
                else
                {
                    return new UserResponse(user);
                }
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı bulunurken bir hata meydana geldi.{ex.Message}");

            }
        }

        public UserResponse FindEmailAndPassword(string email, string password)
        {
            try
            {
                Kullanici user = userRepository.FindByEmailandPassword(email, password);
                if (user == null)
                {
                    return new UserResponse("Kullanıcı bulunamadı");
                }
                else
                {
                    return new UserResponse(user);
                }
            }
            catch (Exception ex)
            {

                return new UserResponse($"Kullanıcı bulunurken bir hata meydana geldi.{ex.Message}");
            }

        }

        public UserResponse GetUserWithToken(string RefreshToken)
        {
            try
            {
                Kullanici user = userRepository.GetUserWithRefreshToken(RefreshToken);
                if (user == null)
                {
                    return new UserResponse($"Kullanıcı bulunamadı.");

                }
                else
                {
                    return new UserResponse(user);
                }
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı bulunurken bir hata meydana geldi::{ex.Message}");
            }

        }

        public void RemoveRefreshToken(Kullanici user)
        {
            try
            {
                userRepository.RemoveRefreshToken(user);
                unitOfWork.CompleteAsync();

            }
            catch (Exception)
            {

            }
        }
        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                userRepository.SaveRefreshToken(userId, refreshToken);
                unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {

            }
        }
    }
}

