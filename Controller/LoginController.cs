using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinimalApiAuth.Models;
using MinimalApiAuth.Repository;
using MinimalApiAuth.Services;
using MinimalApiAuth.ViewModels;

namespace MinimalApiAuth.Controller
{
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserViewModel user)
        {
            var userFounded = UserRepository.Get(user.username, user.password);

            if (userFounded.isValid())
            {
                userFounded.CleanPassword();
                return Ok(new { user = userFounded, token = TokenService.GenerateToken(userFounded, true) });
            }
            else
                return Unauthorized(new { message = "Usuário ou senha inválidos" });
        }
    }
}