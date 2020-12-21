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
    public class SiparisDetayController : ControllerBase
    {

        private readonly ISiparisDetayService siparisDetayService;
        private readonly IMapper mapper;

        public SiparisDetayController(ISiparisDetayService siparisDetayService, IMapper mapper)
        {
            this.siparisDetayService = siparisDetayService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            SiparisDetayListResponse siparisDetayListResponse = await siparisDetayService.ListAsync();
            if (siparisDetayListResponse.Success)
            {
                return Ok(siparisDetayListResponse.SiparisDetayListe);
            }
            else
            {
                return BadRequest(siparisDetayListResponse.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            SiparisDetayResponse siparisDetayResponse = await siparisDetayService.FindByIdAsync(id);
            if (siparisDetayResponse.Success)
            {
                return Ok(siparisDetayResponse.SiparisDetay);

            }
            else
            {
                return BadRequest(siparisDetayResponse.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindBySiparisID(int id)
        {
            SiparisDetayListResponse siparisDetayListResponse = await siparisDetayService.ListBySiparisIdAsync(id);
            if (siparisDetayListResponse.Success)
            {
                return Ok(siparisDetayListResponse.SiparisDetayListe);
            }
            else
            {
                return BadRequest(siparisDetayListResponse.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddSiparisDetay(SiparisDetayResource siparisDetayResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            SiparisDetay siparisDetay = mapper.Map<SiparisDetayResource, SiparisDetay>(siparisDetayResource);

            SiparisDetayResponse siparisDetayResponse = await siparisDetayService.AddSiparisDetayAsync(siparisDetay);
            if (siparisDetayResponse.Success)
            {
                return Ok(siparisDetayResponse.Success);
            }
            else
            {
                return BadRequest(siparisDetayResponse.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSiparisDetay(SiparisDetayResource siparisDetayResouorce, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                SiparisDetay siparisDetay = mapper.Map<SiparisDetayResource, SiparisDetay>(siparisDetayResouorce);
                SiparisDetayResponse siparisDetayResponse = await siparisDetayService.UpdateSiparisDetayAsync(id, siparisDetay);
                if (siparisDetayResponse.Success)
                {
                    return Ok(siparisDetayResponse.Success);
                }
                else
                {
                    return BadRequest(siparisDetayResponse.Message);
                }
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSiparisDetay(int id)
        {
            SiparisDetayResponse siparisDetayResponse = await siparisDetayService.RemoveSiparisDetayAsync(id);

            if (siparisDetayResponse.Success)
            {
                return Ok(siparisDetayResponse.SiparisDetay);
            }
            else
            {
                return BadRequest(siparisDetayResponse.Message);
            }
        }
    }
}
