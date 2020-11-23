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
    public class SiparisDetayService:ISiparisDetayService
    {
        private readonly ISiparisDetayRepository siparisDetayRepository;
        private readonly IUnitOfWork unitOfWork;

        public SiparisDetayService(ISiparisDetayRepository siparisDetayRepository, IUnitOfWork unitOfWork)
        {
            this.siparisDetayRepository = siparisDetayRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<SiparisDetayListResponse> ListAsync()
        {
            try
            {
                IEnumerable<SiparisDetay> siparisDetaylar = await siparisDetayRepository.GetSiparisDetay();
                if(siparisDetaylar == null)
                {
                    return new SiparisDetayListResponse("Siparis Detayı bulunmadı.");
                }
                return new SiparisDetayListResponse(siparisDetaylar);
            }
            catch (Exception ex )
            {
                return new SiparisDetayListResponse($"Siparis Detayları bulunurken bir hata oluştu : {ex.Message}");
            }
        }
        public async Task<SiparisDetayResponse> FindByIdAsync(int id)
        {
            try
            {
                var siparisDetay = await siparisDetayRepository.GetByIdAsync(id);
                if (siparisDetay == null)
                {
                    return new SiparisDetayResponse("Siparis bulunamadı");
                }
                return new SiparisDetayResponse(siparisDetay);
            }
            catch (Exception ex)
            {
                return new SiparisDetayResponse($"Siparis bulunurken bir hata oluştu : {ex.Message}");
            }
        }
        public async Task<SiparisDetayListResponse> ListBySiparisIdAsync(int id)
        {
            try
            {
                IEnumerable<SiparisDetay> siparisDetay = await siparisDetayRepository.GetSiparisDetayWithSiparisId(id);
                if(siparisDetay == null)
                {
                    return new SiparisDetayListResponse("SiparisId ye göre Siparis bulunmadı.");
                }
                return new SiparisDetayListResponse(siparisDetay);
            }
            catch (Exception ex)
            {
                return new SiparisDetayListResponse($"Siparis ID gore aranıken bir hata oluştu : {ex.Message}");
            }
        }
        public async Task<SiparisDetayResponse> AddSiparisDetayAsync(SiparisDetay siparisDetay)
        {
            try
            {
                await siparisDetayRepository.AddSiparisDetayAsync(siparisDetay);
                unitOfWork.CompleteAsync();
                return new SiparisDetayResponse(siparisDetay);

            }
            catch (Exception ex)
            {

                return new SiparisDetayResponse($"Siparis eklenirken bir hata oluştu : {ex.Message}");
            }
        }                   

        public async Task<SiparisDetayResponse> RemoveSiparisDetayAsync(int id)
        {
            try
            {
                SiparisDetay siparisDetay = await siparisDetayRepository.GetByIdAsync(id);
                if(siparisDetay== null)
                {
                    return new SiparisDetayResponse("Silinecej siparis bulunamadı.");
                }
                else
                {
                    await siparisDetayRepository.RemoveSiparisDetayAsync(id);
                    unitOfWork.CompleteAsync();
                    return new SiparisDetayResponse(siparisDetay);
                }
            }
            catch (Exception ex )
            {
                return new SiparisDetayResponse($"Siparis silinirken bşr hata oluştu : {ex.Message}");
            }
        }
        public async Task<SiparisDetayResponse> UpdateSiparisDetayAsync(int siparisDetayId, SiparisDetay siparisDetay)
        {
            try
            {
                SiparisDetay siparisDetay1 = await siparisDetayRepository.GetByIdAsync(siparisDetayId);
                if (siparisDetay1 == null)
                {
                    return new SiparisDetayResponse("Güncellenicek Siparis bulunamdı.");
                }
                else
                {
                    siparisDetayRepository.UpdateSiparisDetayAsync(siparisDetay);
                    unitOfWork.CompleteAsync();
                    return new SiparisDetayResponse(siparisDetay);
                }
            }
            catch (Exception ex )
            {
                return new SiparisDetayResponse($"Siparis detay güncellenirken bir hata oluştu : {ex.Message}");
            }
        }
    }
}
