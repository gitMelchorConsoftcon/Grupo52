using Grupo52.Api.Models;

namespace Grupo52.Api.DTOS
{
    public class JugadorDTO
    {
    
        public int IdJugador { get; set; }

        public string Nombre { get; set; }

        public int Numero { get; set; }

        public int IdEquipo { get; set; }

        public string NombreEquipo { get; set; }


        public JugadorDTO(Jugador jugador )
        {
            IdJugador = jugador.IdJugador;
            Nombre = jugador.Nombre;
            IdEquipo = jugador.IdEquipo;
            Numero = jugador.Numero;
            NombreEquipo = jugador.Equipo.Nombre;
        }

    }
}
