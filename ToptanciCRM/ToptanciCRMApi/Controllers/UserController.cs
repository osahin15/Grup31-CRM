using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToptanciCRMApi.Domain;
using ToptanciCRMApi.Domain.Response;
using ToptanciCRMApi.Domain.Services;
using ToptanciCRMApi.Resource;

namespace ToptanciCRMApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;

            UserResponse userResponse = userService.FindById(int.Parse(userId));

            if (userResponse.Success)
            {
                return Ok(userResponse.user);
            }
            else
            {
                return BadRequest(userResponse.Message);
            }

        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddUser(UserResource userResource)
        {
            Kullanici user = mapper.Map<UserResource, Kullanici>(userResource);

            UserResponse userResponse = userService.AddUser(user);

            if (userResponse.Success)
            {
                return Ok(userResponse.user);
            }
            else
            {
                return BadRequest(userResponse.Message);
            }

        }
    }
}
