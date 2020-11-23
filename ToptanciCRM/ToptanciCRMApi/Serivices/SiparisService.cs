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
    public class SiparisService:ISiparisService
    {
        private readonly ISiparisRepository siparisRepository;
        private readonly IUnitOfWork unitOfWork;

        public SiparisService(ISiparisRepository siparisRepository, IUnitOfWork unitOfWork)
        {
            this.siparisRepository = siparisRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<SiparisListResponse> GetList()
        {
            try
            {
                IEnumerable<Siparis> siparisler = await siparisRepository.GetSiparisAsync();
                return new SiparisListResponse(siparisler);
            }
            catch (Exception ex)
            {
                return new SiparisListResponse($"Siparisleri  bulurken bir hata oluştu : {ex.Message}");
            }
        }
        public async Task<SiparisResponse> GetById(int id)
        {
            try
            {
                var siparis = await siparisRepository.GetByIdAsync(id);
                return new SiparisResponse(siparis);
            }
            catch (Exception ex)
            {
                return new SiparisResponse($"Siparisiniz getilirken hata oluştu{ex.Message}");
            }
        }

        public async Task<SiparisResponse> AddSiparisAsync(Siparis siparis)
        {
            try
            {
                await siparisRepository.AddSiparisAsync(siparis);
                unitOfWork.CompleteAsync();
                return new SiparisResponse(siparis);
            }
            catch (Exception)
            {
                return new SiparisResponse(siparis);
            }
        }

        public async Task<SiparisResponse> DeleteSiparisAsync(int id)
        {
            try
            {
                var siparis = await siparisRepository.GetByIdAsync(id);
                if (siparis == null)
                {
                    return new SiparisResponse("Siparis Bulunamadı.");
                }
                else
                {
                    await siparisRepository.RemoveSiparisAsync(id);
                    unitOfWork.CompleteAsync();
                    return new SiparisResponse(siparis);
                }                
            }
            catch (Exception ex)
            {

                return new SiparisResponse($"Siparis Silinirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<SiparisListResponse> GetByBayiIdSiparis(int bayiId)
        {
            try
            {
                IEnumerable<Siparis> siparisler = await siparisRepository.GetByBayiIdSiparis(bayiId);

                return new SiparisListResponse(siparisler);
            }
            catch (Exception ex )
            {
                return new SiparisListResponse($"Siparisler Listelenirken bir hata oluştu : {ex.Message}");
            }
        }

        

        
    }
}
