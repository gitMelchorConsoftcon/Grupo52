using Grupo52.Api.Data;
using Grupo52.Api.DTOS;
using Grupo52.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly SoccerContext _context;

        public JugadoresController(SoccerContext context)
        {
            _context = context;
        }

        // GET: api/Jugadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JugadorDTO>>> GetJugadores()
        {
            var jugadores = await _context.Jugadores
                                          .Include(x=> x.Equipo)
                                          .Where(x=> x.Activo==true  )
                                          .ToListAsync();

            var jugadoresDTO = new List<JugadorDTO>();

            foreach (var item in jugadores)
            {
                var jugadorDto = new JugadorDTO(item);
                jugadoresDTO.Add(jugadorDto);
            }


            return jugadoresDTO;
        }

        // GET: api/Jugadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jugador>> GetJugador(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);

            if (jugador == null)
            {
                return NotFound();
            }

            return jugador;
        }

        // PUT: api/Jugadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJugador(int id, Jugador jugador)
        {
            if (id != jugador.IdJugador)
            {
                return BadRequest();
            }

            _context.Entry(jugador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JugadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Jugadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jugador>> PostJugador(JugadorNuevoDTO jugador)
        {
            var obj = new Jugador(jugador);


            _context.Jugadores.Add(obj);
            await _context.SaveChangesAsync();

            var resultado = await _context.Jugadores.Include(x => x.Equipo).Where(x=> x.IdJugador==obj.IdJugador).FirstOrDefaultAsync();
            return CreatedAtAction("GetJugador", new { id = resultado.IdJugador }, new JugadorDTO( resultado));
        }

        // DELETE: api/Jugadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJugador(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }

            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugadores.Any(e => e.IdJugador == id);
        }
    }
}
