using Grupo52.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo52.Api.Data
{
    public class SoccerContext: DbContext
    {
        public SoccerContext(DbContextOptions<SoccerContext> options ):base(options)
        {

        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
    }
}
