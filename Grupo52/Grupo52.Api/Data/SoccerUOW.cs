using Grupo52.Api.Interfaces;
using Grupo52.Api.Models;

namespace Grupo52.Api.Data
{
    public class SoccerUOW : ISoccerUOW
    {


        private readonly SoccerContext Contexto;

        public SoccerUOW(SoccerContext contexto)
        {
            Contexto = contexto;
        }


        private readonly IRepositorioGenerico<Equipo> _Equipos;
        public IRepositorioGenerico<Equipo> Equipos => _Equipos ?? new RepositorioGenerico<Equipo>(Contexto);

        private readonly IRepositorioGenerico<Jugador> _Jugadores;
        public IRepositorioGenerico<Jugador> Jugadores => _Jugadores ?? new RepositorioGenerico<Jugador>(Contexto);

        private readonly IRepositorioGenerico<Partido> _Partidos;
        public IRepositorioGenerico<Partido> Partidos => _Partidos ?? new RepositorioGenerico<Partido>(Contexto);

       
    }
}
