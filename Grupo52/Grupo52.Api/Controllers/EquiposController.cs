using Grupo52.Api.Interfaces;
using Grupo52.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {

        public IRepositorioGenerico<Equipo> _bd;

        public EquiposController(IRepositorioGenerico<Equipo> bd)
        {
            _bd = bd;
        }


        [HttpGet] // Sirve para obtener informacion del servidor
        public IActionResult Get()
        {
            return Ok(_bd.Listar());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEquipo(int id)
        {
            Equipo equipo = _bd.Buscar(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return Ok(equipo);
        }

        [HttpPost]  // sirve para guardar informacion
        public IActionResult GuardarEquipo (Equipo equipo)
        {
                equipo = _bd.Guardar(equipo);
                return Ok(equipo);
        }


        [HttpPut] // sirve para modificar informacion
        [Route("{id}")]         
        public IActionResult ModificarEquipo(int id ,Equipo equipo)
        {
                equipo = _bd.Modificar(id, equipo);
                return Ok(equipo);          
        }


        [HttpDelete]   // sirver para borrar
        [Route("{id}")]              
        public IActionResult BorrarEquipo (int id)
        {

            Equipo borrar =  _bd.Borrar(id);
            return Ok(borrar);
        }
 
    }
}
