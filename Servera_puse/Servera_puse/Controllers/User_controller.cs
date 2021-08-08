using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Servera_puse.Services;
using Servera_puse.Entities;
using Servera_puse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servera_puse.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class User_controller : ControllerBase
    {
        private I_User_service i_User_Service;

        public User_controller(I_User_service service)
        {
            i_User_Service = service;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Autentifikacija([FromBody] Autentifikacijas_modelis _Modelis)
        {
            var user = i_User_Service.Autentifikacija(_Modelis.Username, _Modelis.Password);

            if(user == null)
                return BadRequest(new { message = "Parole vai lietotaja vards ir nekorekts" });
            else
                return Ok(user);
        }
    }
}
