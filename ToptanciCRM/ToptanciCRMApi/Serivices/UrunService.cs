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
    public class UrunService:IUrunService
    {
        private readonly IUrunRepository urunRepository;
        private readonly IUnitOfWork unitOfWork;
        public UrunService(IUrunRepository urunRepository, IUnitOfWork unitOfWork)
        {
            this.urunRepository = urunRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<UrunListResponse> GetList()
        {
            try
            {
                var urunler = await urunRepository.GetList();
                if (urunler == null)
                {
                    return new UrunListResponse("Urun bulunamadı.");
                }
                else
                {
                    return new UrunListResponse(urunler);
                }
            }
            catch (Exception ex)
            {
                return new UrunListResponse($"Urun bulunurken bir hata oluştu.{ex.Message}");
            }
        }
        public async Task<UrunResponse> GetById(int id)
        {
            try
            {
                var urun = await urunRepository.GetByIdUrun(id);
                if (urun == null)
                {
                    return new UrunResponse("Urun bulunamadı");
                }
                else
                {
                    return new UrunResponse(urun);
                }
            }
            catch (Exception ex)
            {
                return new UrunResponse($"Urun bulunurken bir hata oluştu{ex.Message}");
            }
        }
        public async Task<UrunResponse> AddUrunAsync(Urun urun)
        {
            try
            {
                await urunRepository.AddUrunAsync(urun);
                unitOfWork.CompleteAsync();

                return new UrunResponse(urun);
            }
            catch (Exception ex)
            {
                return new UrunResponse($"Urun eklenirken bir hata oluştu{ex.Message}");
            }
        }
        public async Task<UrunResponse> DeleteAsync(int id )
        {
            try
            {
                var urun = await urunRepository.GetByIdUrun(id);
                if (urun == null)
                {
                    return new UrunResponse("Urun bulunamadı.");
                }
                else
                {
                    await urunRepository.Delete(id);
                    unitOfWork.CompleteAsync();

                    return new UrunResponse(urun);
                }
            }
            catch (Exception ex)
            {
                return new UrunResponse($"Urun silinirken bir hata oluştu : {ex.Message}");
            }
        }
        public async Task<UrunResponse> UpdateAsync(Urun urun, int id)
        {
            try
            {
                var urunguncel = await urunRepository.GetByIdUrun(id);
                if(urunguncel == null)
                {
                    return new UrunResponse("Urun bulunamadı.");
                }
                else
                {
                    urunguncel.UrunAd = urun.UrunAd;
                    urunguncel.UrunFiyat = urun.UrunFiyat;
                    urunguncel.KategoriId = urun.KategoriId;


                    urunRepository.Update(urunguncel);
                    unitOfWork.CompleteAsync();

                    return new UrunResponse(urunguncel);

                }
            }
            catch (Exception ex)
            {
                return new UrunResponse($"Urun güncellenirken bir arıca oluştu.{ex.Message}");
            }
        }
    }
}
