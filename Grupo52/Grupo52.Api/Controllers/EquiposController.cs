using Microsoft.AspNetCore.Mvc;
using Grupo52.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        List<Equipo> Equipos = new List<Equipo>();
        public EquiposController()
        {
            
            Equipos.Add(new Equipo { IdEquipo = 1, Nombre = "Pumas", Logotipo = "logopumas.jpg", Ciudad = "Monterrey" });
            Equipos.Add(new Equipo { IdEquipo = 2, Nombre = "Pumas", Logotipo = "logopumas.jpg", Ciudad = "Monterrey" });
            Equipos.Add(new Equipo { IdEquipo = 3, Nombre = "Pumas", Logotipo = "logopumas.jpg", Ciudad = "Monterrey" });
            Equipos.Add(new Equipo { IdEquipo = 4, Nombre = "Pumas", Logotipo = "logopumas.jpg", Ciudad = "Monterrey" });
        }


        [HttpGet] // Sirve para obtener informacion del servidor
        public IActionResult Get()
        {      
            return Ok(Equipos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEquipo(int id)
        {
            var equipo = Equipos.Where(x=> x.IdEquipo==id).FirstOrDefault();

            if (equipo == null)
                return NotFound();

            return Ok(equipo);
        }

        [HttpPost]  // sirve para guardar informacion
        public IActionResult GuardarEquipo (Equipo equipo)
        {

            var eq = new Equipo
            {
                IdEquipo=equipo.IdEquipo,
                Nombre=equipo.Nombre,
                Logotipo=equipo.Logotipo,
                Ciudad=equipo.Ciudad
            };

            Equipos.Add(eq);
            return Ok(Equipos);
        }


        [HttpPut] // sirve para modificar informacion
        [Route("{id}")]         
        public IActionResult ModificarEquipo(int id ,Equipo equipo)
        {

            var modificar = Equipos.Where(x => x.IdEquipo == id).FirstOrDefault();

            if (modificar!= null)
            {
                modificar.Nombre = equipo.Nombre;
                modificar.Ciudad = equipo.Ciudad;
                modificar.Logotipo = equipo.Logotipo;
                
            }
            return Ok(modificar);
        }


        [HttpDelete]   // sirver para borrar
        [Route("{id}")]              
        public IActionResult BorrarEquipo (int id)
        {

            var borrar = Equipos.Where(x => x.IdEquipo == id).FirstOrDefault();

            Equipos.Remove(borrar);

            return Ok(Equipos);
        }
 
    }
}
