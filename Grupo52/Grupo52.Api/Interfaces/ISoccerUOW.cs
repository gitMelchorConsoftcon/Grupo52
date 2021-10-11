using Grupo52.Api.Models;

namespace Grupo52.Api.Interfaces
{
    public interface ISoccerUOW
    {
        IRepositorioGenerico<Equipo> Equipos { get; }
        IRepositorioGenerico<Jugador> Jugadores { get; }
        IRepositorioGenerico<Partido> Partidos { get; }

       IRepositorioUsuario Usuarios { get; }

    }
}
