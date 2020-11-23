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
    public class UrunController : ControllerBase
    {
        private readonly IUrunService urunService;
        private readonly IMapper mapper;
        public UrunController(IUrunService urunService, IMapper mapper)
        {
            this.urunService = urunService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            UrunListResponse urunListResponse = await urunService.GetList();
            if (urunListResponse.Success)
            {
                return Ok(urunListResponse.Uruns);
            }
            else
            {
                return BadRequest(urunListResponse.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            UrunResponse urunResponse = await urunService.GetById(id);
            if (urunResponse.Success)
            {
                return Ok(urunResponse.Urun);

            }
            else
            {
                return BadRequest(urunResponse.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddUrun(UrunResource urunResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            Urun urun = mapper.Map<UrunResource, Urun>(urunResource);

            UrunResponse urunResponse = await urunService.AddUrunAsync(urun);
            if (urunResponse.Success)
            {
                return Ok(urunResponse.Success);
            }
            else
            {
                return BadRequest(urunResponse.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUrun(UrunResource urunResource, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                Urun urun = mapper.Map<UrunResource, Urun>(urunResource);
                UrunResponse urunResponse = await urunService.UpdateAsync(urun,id);
                if (urunResponse.Success)
                {
                    return Ok(urunResponse.Success);
                }
                else
                {
                    return BadRequest(urunResponse.Message);
                }
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUrun(int id)
        {
            UrunResponse urunResponse = await urunService.DeleteAsync(id);

            if (urunResponse.Success)
            {
                return Ok(urunResponse.Urun);
            }
            else
            {
                return BadRequest(urunResponse.Message);
            }
        }
    }
}
