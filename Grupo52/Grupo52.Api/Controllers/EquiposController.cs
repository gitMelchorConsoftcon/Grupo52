using Grupo52.Api.Data;
using Grupo52.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
      
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
            return BadRequest(equipo);
        }


        [HttpPut] // sirve para modificar informacion
        [Route("{id}")]         
        public IActionResult ModificarEquipo(int id ,Equipo equipo)
        {

            if(ModelState.IsValid)
            {
                var modficar = _bd.Equipos.Find(id);

                if (modficar!=null)
                {
                    modficar.Nombre = equipo.Nombre;
                    modficar.Ciudad = equipo.Ciudad;
                    modficar.Logotipo = equipo.Logotipo;
                    modficar.Capacidad = equipo.Capacidad;
                    modficar.NombreEstadio = equipo.NombreEstadio;

                    _bd.Update(modficar);
                    _bd.SaveChanges();

                    return Ok(modficar);
                }

                return NotFound("No se encontro el equipo");
            }

            return BadRequest();

        }


        [HttpDelete]   // sirver para borrar
        [Route("{id}")]              
        public IActionResult BorrarEquipo (int id)
        {

            var borrar = _bd.Equipos.Find(id);
           
            if (borrar!=null)
            {
                _bd.Remove(borrar);
                _bd.SaveChanges();
                return Ok(borrar);
            }
            return NotFound("No se encontro el equipo");



        }
 
    }
}
