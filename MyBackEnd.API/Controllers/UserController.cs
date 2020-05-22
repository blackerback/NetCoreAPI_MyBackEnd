using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Core.Entities.Concrete;

namespace MyBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getclaim")]
        public IActionResult GetUserClaim(int userId)
        {
            var user = _userService.GetById(userId);
            if (!user.Success)
                return BadRequest(user.Message);
            else
            {
                var result = _userService.GetClaims(user.Data);
                if (result.Success)
                    return Ok(result.Data);
                else
                    return BadRequest(result.Message);
            }
            
        }
    }
}