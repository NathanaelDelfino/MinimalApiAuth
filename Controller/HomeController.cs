using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MinimalApiAuth.Controller
{
    [Route("v1")]
    public class HomeController : ControllerBase
    {
        [HttpGet("anonymous")]
        [AllowAnonymous]
        public IActionResult Anonymous()
        {
            return Ok(new { message = "Anônimo" });
        }

        [HttpGet("authenticated")]
        [Authorize]
        public IActionResult Authenticated()
        {
            return Ok($"Autenticado {User.Identity.Name}");
        }

        [HttpGet("usuariosautenticados")]
        [Authorize(Roles = "admin,user")]
        public IActionResult AuthenticadUsers()
        {
            return Ok($"Usuario admin/user {User.Identity.Name}");
        }
        [HttpGet("usuarioadminautenticado")]
        [Authorize(Roles = "admin")]
        public IActionResult AuthenticatedAdmin()
        {
            return Ok($"Usuario Admin {User.Identity.Name}");
        }
    }
}