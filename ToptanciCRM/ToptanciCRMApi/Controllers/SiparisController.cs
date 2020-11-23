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
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisService siparisService;
        private readonly IMapper mapper;

        public SiparisController(ISiparisService siparisService, IMapper mapper)
        {
            this.siparisService = siparisService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            SiparisListResponse siparisListResponse = await siparisService.GetList();
            if (siparisListResponse.Success)
            {
                return Ok(siparisListResponse.Siparisler);
            }
            else
            {
                return BadRequest(siparisListResponse.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            SiparisResponse siparisResponse = await siparisService.GetById(id);
            if (siparisResponse.Success)
            {
                return Ok(siparisResponse.Siparis);

            }
            else
            {
                return BadRequest(siparisResponse.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> FindByBayiId(int id)
        {
            SiparisListResponse siparisListResponse = await siparisService.GetByBayiIdSiparis(id);
            if (siparisListResponse.Success)
            {
                return Ok(siparisListResponse.Siparisler);
            }
            else
            {
                return BadRequest(siparisListResponse.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddKategori(SiparisResource siparisResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            Siparis siparis = mapper.Map<SiparisResource, Siparis>(siparisResource);

            SiparisResponse siparisResponse = await siparisService.AddSiparisAsync(siparis);
            if (siparisResponse.Success)
            {
                return Ok(siparisResponse.Success);
            }
            else
            {
                return BadRequest(siparisResponse.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteKategori(int id)
        {
            SiparisResponse siparisResponse = await siparisService.DeleteSiparisAsync(id);

            if (siparisResponse.Success)
            {
                return Ok(siparisResponse.Siparis);
            }
            else
            {
                return BadRequest(siparisResponse.Message);
            }
        }

    }
}
