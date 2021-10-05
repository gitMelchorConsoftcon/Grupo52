using Grupo52.Api.Interfaces;
using Grupo52.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {

        public ISoccerUOW _bd;

        public EquiposController(ISoccerUOW bd)
        {
            _bd = bd;
        }


        [HttpGet] // Sirve para obtener informacion del servidor
        public IActionResult Get()
        {
            return Ok(_bd.Equipos.Listar());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEquipo(int id)
        {
            Equipo equipo = _bd.Equipos.Buscar(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return Ok(equipo);
        }

        [HttpPost]  // sirve para guardar informacion
        public IActionResult GuardarEquipo (Equipo equipo)
        {
                equipo = _bd.Equipos.Guardar(equipo);
                return Ok(equipo);
        }


        [HttpPut] // sirve para modificar informacion
        [Route("{id}")]         
        public IActionResult ModificarEquipo(int id ,Equipo equipo)
        {
                equipo = _bd.Equipos.Modificar(id, equipo);
                return Ok(equipo);          
        }


        [HttpDelete]   // sirver para borrar
        [Route("{id}")]              
        public IActionResult BorrarEquipo (int id)
        {

            Equipo borrar =  _bd.Equipos.Borrar(id);
            return Ok(borrar);
        }
 
    }
}
