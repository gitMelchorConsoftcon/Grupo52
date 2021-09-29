using Grupo52.Api.Data;
using Grupo52.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {

        SoccerContext _bd;

        public PartidosController(SoccerContext bd)
        {
            _bd = bd;
        }


        [HttpGet] // Sirve para obtener informacion del servidor
        public IActionResult Get()
        {
            return Ok(_bd.Partidos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPartido(int id)
        {
            var partido = _bd.Partidos.Find(id);

            if (partido == null)
                return NotFound();

            return Ok(partido);
        }

        [HttpPost]  // sirve para guardar informacion
        public IActionResult Guardarpartido(Partido partido)
        {
            if (ModelState.IsValid)
            {
                _bd.Partidos.Add(partido);
                _bd.SaveChanges();
                return Ok(partido);
            }
            return BadRequest(partido);
        }


        [HttpPut] // sirve para modificar informacion
        [Route("{id}")]
        public IActionResult Modificarpartido(int id, Partido partido)
        {

            if (ModelState.IsValid)
            {
                var modficar = _bd.Partidos.Find(id);

                if (modficar != null)
                {
                    modficar.fecha = partido.fecha;
                    modficar.IdEquipoLocal = partido.IdEquipoLocal;
                    modficar.IdEquipoVisitante = partido.IdEquipoVisitante;
                    modficar.GolLocal = partido.GolLocal;
                    modficar.GolVisitante = partido.GolVisitante;

                    _bd.Update(modficar);
                    _bd.SaveChanges();

                    return Ok(modficar);
                }

                return NotFound("No se encontro el partido");
            }

            return BadRequest();

        }


        [HttpDelete]   // sirver para borrar
        [Route("{id}")]
        public IActionResult Borrarpartido(int id)
        {

            var borrar = _bd.Partidos.Find(id);

            if (borrar != null)
            {
                _bd.Remove(borrar);
                _bd.SaveChanges();
                return Ok(borrar);
            }
            return NotFound("No se encontro el partido");



        }


    }
}
