using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Interface;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AccountController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [HttpGet]
        [Route("Get")]
        public string Get()
        {
            return "Vaue";
        }

        [HttpGet]
        [Route("GetOne")]
        public string GetOne()
        {
            return "Hellaw";
        } 

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLogin userLogin)
        {
            var token = jwtAuthenticationManager.Authenticate(userLogin.UserName, userLogin.Password);

            if (token == null)
                return Unauthorized("Error Login");

            return Ok(token);
        }
    }
}
