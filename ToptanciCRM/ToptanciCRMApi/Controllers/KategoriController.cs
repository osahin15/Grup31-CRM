using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Domain.Response;
using ToptanciCRMApi.Domain.Services;
using ToptanciCRMApi.Extencions;
using ToptanciCRMApi.Resource;

namespace ToptanciCRMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {

        private readonly IKategoriService kategoriService;
        private readonly IMapper mapper;

        public KategoriController(IKategoriService kategoriService, IMapper mapper)
        {
            this.kategoriService = kategoriService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            KategoriListResponse kategoriListResponse = await kategoriService.ListAsync();
            if (kategoriListResponse.Success)
            {
                return Ok(kategoriListResponse.Kategoriler);
            }
            else
            {
                return BadRequest(kategoriListResponse.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            KategoriResponse kategoriResponse = await kategoriService.FindByIdAsync(id);
            if (kategoriResponse.Success)
            {
                return Ok(kategoriResponse.Kategori);

            }
            else
            {
                return BadRequest(kategoriResponse.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddKategori(KategoriResource kategoriResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            Kategori kategori = mapper.Map<KategoriResource, Kategori>(kategoriResource);

            KategoriResponse kategoriResponse = await kategoriService.AddKategoriAsync(kategori);
            if (kategoriResponse.Success)
            {
                return Ok(kategoriResponse.Success);
            }
            else
            {
                return BadRequest(kategoriResponse.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateKategori(KategoriResource kategoriResource, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                Kategori kategori = mapper.Map<KategoriResource, Kategori>(kategoriResource);
                KategoriResponse kategoriResponse = await kategoriService.UpdateKategori(id, kategori);
                if (kategoriResponse.Success)
                {
                    return Ok(kategoriResponse.Success);
                }
                else
                {
                    return BadRequest(kategoriResponse.Message);
                }
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteKategori(int id)
        {
            KategoriResponse kategoriResponse = await kategoriService.RemoveKategoriAsync(id);

            if (kategoriResponse.Success)
            {
                return Ok(kategoriResponse.Kategori);
            }
            else
            {
                return BadRequest(kategoriResponse.Message);
            }
        }

    }
}
