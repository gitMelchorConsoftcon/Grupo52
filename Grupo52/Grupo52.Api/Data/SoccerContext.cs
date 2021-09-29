using Grupo52.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo52.Api.Data
{
    public class SoccerContext: DbContext
    {
        public SoccerContext(DbContextOptions<SoccerContext> options ):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Equipo>().HasMany(x => x.PartidoLocal).WithOne(x => x.EquipoLocal).HasForeignKey(x => x.IdEquipoLocal);
            modelBuilder.Entity<Equipo>().HasMany(x => x.PartidoVisitante).WithOne(x => x.EquipoVisitante).HasForeignKey(x => x.IdEquipoVisitante);

        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Partido> Partidos { get; set; }
    }
}
