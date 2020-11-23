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
    public class BayiService : IBayiService
    {

        private readonly IBayiRepository bayiRepository;
        private readonly IUnitOfWork unitOfWork;

        public BayiService(IBayiRepository bayiRepository, IUnitOfWork unitOfWork)
        {
            this.bayiRepository = bayiRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BayiResponse> AddBayiAsync(Bayi bayi)
        {
            try
            {
                await bayiRepository.AddBayiAsync(bayi);
                unitOfWork.CompleteAsync();

                return new BayiResponse(bayi);

            }
            catch (Exception ex)
            {
                return new BayiResponse($"Bayi eklenirken bir hata oluştu : {ex.Message}");
            }
        }

        public async Task<BayiResponse> FindByIdAsync(int bayiId)
        {
            try
            {
                var bayi = await bayiRepository.FindByIdAsync(bayiId);
                if(bayi== null)
                {
                    return new BayiResponse("Bayi Bulunamadı.");
                }
                return new BayiResponse(bayi);
            }
            catch (Exception ex)
            {
                return new BayiResponse($"Bayi Bulunurken hata oluştu : {ex.Message}");
                
            }
        }

        public async Task<BayiListResponse> ListAsyc()
        {
            try
            {

                var bayiler = await bayiRepository.ListBayiAsync();
                if (bayiler == null)
                {
                    return new BayiListResponse("Kayıtlı bayi yok.");
                }
                return new BayiListResponse(bayiler);

            }
            catch (Exception ex )
            {
                return new BayiListResponse($"Bayiler bulunurklen hata oluştu.{ex.Message}");                
            }
        }

        public async Task<BayiResponse> RemoveBayiAsync(int bayiId)
        {
            try
            {
                Bayi bayi = await bayiRepository.FindByIdAsync(bayiId);
                if (bayi == null)
                {
                    return new BayiResponse("Bayi bulunmadı");
                }
                else
                {
                    await bayiRepository.RemoveBayiAsync(bayiId);
                    unitOfWork.CompleteAsync();
                    return new BayiResponse(bayi);
                }
            }
            catch (Exception ex)
            {
                return new BayiResponse($"Bayi silinirken hata oluştu : {ex.Message}");
            }
        }

        public async Task<BayiResponse> UpdateBayiAsync(Bayi bayi, int bayiId)
        {
            try
            {
                Bayi bayiguncel = await bayiRepository.FindByIdAsync(bayiId);

                if (bayiguncel == null)
                {
                    return new BayiResponse("Bayi bulamadı.");    
                }
                else
                {

                    bayiguncel.BayiAd = bayi.BayiAd;
                    bayiguncel.BayiMail = bayi.BayiMail;
                    bayiguncel.BayiAdres = bayi.BayiAdres;

                    bayiRepository.UpdateBayiAsync(bayiguncel);
                    unitOfWork.CompleteAsync();

                    return new BayiResponse(bayiguncel);
                }
            }
            catch (Exception ex)
            {

                return new BayiResponse($"Bayi güncellenirken bir hata oluştu.{ex.Message}");
            }
        }
    }
}
