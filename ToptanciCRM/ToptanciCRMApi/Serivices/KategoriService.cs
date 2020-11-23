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
    public class KategoriService : IKategoriService
    {
        private readonly IKategoriRepository kategoriRepository;
        private readonly IUnitOfWork unitOfWork;

        public KategoriService(IKategoriRepository kategoriRepository, IUnitOfWork unitOfWork)
        {
            this.kategoriRepository = kategoriRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<KategoriListResponse> ListAsync()
        {
            try
            {
                var kategoriler = await kategoriRepository.GetKategori();

                if (kategoriler == null)
                {
                    return new KategoriListResponse("Kategoriler bulunamadı.");
                }
                return new KategoriListResponse(kategoriler);
            }
            catch (Exception ex)
            {
                return new KategoriListResponse($"Kategoriler bulunurken bir sorun oluştu.{ex.Message}");
            }
        }
        public async Task<KategoriResponse> FindByIdAsync(int kategoriId)
        {
            try
            {
                Kategori kategori = await kategoriRepository.GetByIdAsync(kategoriId);
                if (kategori == null)
                {
                    return new KategoriResponse("Kategori Bulunamadı.");
                }
                return new KategoriResponse(kategori);

            }
            catch (Exception ex)
            {
                return new KategoriResponse($"Kategori bulunurken bir hata oluştu.{ex.Message}");
            }
        }
        public async Task<KategoriResponse> AddKategoriAsync(Kategori kategori)
        {
            try
            {
                await kategoriRepository.AddKategoriAsync(kategori);
                unitOfWork.CompleteAsync();

                return new KategoriResponse(kategori);
            }
            catch (Exception ex)
            {
                return new KategoriResponse($"Kategoriler eklenirken bir hata oluştu : {ex.Message}");
            }
        }          
        public async Task<KategoriResponse> RemoveKategoriAsync(int kategoriId)
        {
            try
            {
                Kategori kategori = await kategoriRepository.GetByIdAsync(kategoriId);
                if (kategori == null)
                {
                    return new KategoriResponse("Kategori bulunamadı.");
                }
                else
                {
                    await kategoriRepository.RemoveKategoriAsync(kategoriId);
                    unitOfWork.CompleteAsync();
                    return new KategoriResponse(kategori);
                }
            }
            catch (Exception ex)
            {
                return new KategoriResponse($"kategori silinirken hata oluştu.{ex.Message}");
            }
        }
        public async  Task<KategoriResponse> UpdateKategori(int kategoriId, Kategori kategori)
        {
            try
            {
                Kategori kategoriguncel = await kategoriRepository.GetByIdAsync(kategoriId);

                if (kategoriguncel == null)
                {
                    return new KategoriResponse("Kategori bulunamadı.");
                }
                else
                {
                    kategoriguncel.KategoriAd = kategori.KategoriAd;
                    kategoriRepository.UpdateKategoriAsync(kategoriguncel);
                    unitOfWork.CompleteAsync();
                    return new KategoriResponse(kategoriguncel);
                }
            }
            catch (Exception ex)
            {
                return new KategoriResponse($"Kategori güncellenirken bir hata oluştu.{ex.Message}");
            }
        }
    }
}
