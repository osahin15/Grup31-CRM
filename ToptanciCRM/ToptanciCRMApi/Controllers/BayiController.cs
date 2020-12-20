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
    public class BayiController : ControllerBase
    {

        private readonly IBayiService bayiService;
        private readonly IMapper mapper;

        public BayiController(IBayiService bayiService, IMapper mapper)
        {
            this.bayiService = bayiService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {

            BayiListResponse bayiListResponse = await bayiService.ListAsyc();
            if (bayiListResponse.Success)
            {
                return Ok(bayiListResponse.Bayiler);
            }
            else
            {
                return BadRequest(bayiListResponse.Message);
            }

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            BayiResponse bayiResponse = await bayiService.FindByIdAsync(id);
            if (bayiResponse.Success)
            {
                return Ok(bayiResponse.Bayi);

            }
            else
            {
                return BadRequest(bayiResponse.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddBayi(BayiResource bayiResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            Bayi bayi = mapper.Map<BayiResource, Bayi>(bayiResource);

            BayiResponse bayiResponse = await bayiService.AddBayiAsync(bayi);
            if (bayiResponse.Success)
            {
                return Ok(bayiResponse.Bayi);
            }
            else
            {
                return BadRequest(bayiResponse.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBayi(BayiResource bayiResource, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                Bayi bayi = mapper.Map<BayiResource, Bayi>(bayiResource);
                BayiResponse bayiResponse = await bayiService.UpdateBayiAsync(bayi, id);
                if (bayiResponse.Success)
                {
                    return Ok(bayiResponse.Bayi);
                }
                else
                {
                    return BadRequest(bayiResponse.Message);
                }
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBayi(int id)
        {
            BayiResponse bayiResponse = await bayiService.RemoveBayiAsync(id);

            if (bayiResponse.Success)
            {
                return Ok(bayiResponse.Bayi);
            }
            else
            {
                return BadRequest(bayiResponse.Message);
            }
        }
    }
}
