using Microsoft.AspNetCore.Mvc;
using Grupo52.Api.Models;
using System.Collections.Generic;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            List<Equipo> Equipos = new List<Equipo>();
/*
            var equipo = new Equipo
            {
                IdEquipo=1,
                Nombre="Pumas",
                Logotipo="logopumas.jpg",
                Ciudad="Monterrey"
            };
*/
            Equipos.Add(new Equipo { IdEquipo = 1,Nombre = "Pumas",Logotipo = "logopumas.jpg",Ciudad = "Monterrey"});
            Equipos.Add(new Equipo { IdEquipo = 2, Nombre = "Pumas", Logotipo = "logopumas.jpg", Ciudad = "Monterrey" });
            Equipos.Add(new Equipo { IdEquipo = 3, Nombre = "Pumas", Logotipo = "logopumas.jpg", Ciudad = "Monterrey" });


            return Ok(Equipos);
        }
    }
}
