using Microsoft.AspNetCore.Mvc;
using Grupo52.Api.Models;
using System.Collections.Generic;
using System.Linq;
using Grupo52.Api.Data;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        List<Equipo> Equipos = new List<Equipo>();

        SoccerContext _bd;

        public EquiposController(SoccerContext bd)
        {
            _bd = bd;
        }


        [HttpGet] // Sirve para obtener informacion del servidor
        public IActionResult Get()
        {      
            return Ok(_bd.Equipos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEquipo(int id)
        {
            var equipo = _bd.Equipos.Find(id);

            if (equipo == null)
                return NotFound();

            return Ok(equipo);
        }

        [HttpPost]  // sirve para guardar informacion
        public IActionResult GuardarEquipo (Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _bd.Equipos.Add(equipo);
                _bd.SaveChanges();
                return Ok(equipo);
            }
            return BadRequest(Equipos);
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
