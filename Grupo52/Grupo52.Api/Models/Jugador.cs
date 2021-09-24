using Grupo52.Api.DTOS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo52.Api.Models
{
    [Table("Jugadores")] 
    public class Jugador
    {
       
        [Key]
        public int IdJugador { get; set; }

        [MaxLength(90)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Range(1,100)]
        public int Numero { get; set; }

        [Required]
        public int IdEquipo { get; set; }

        [Required]
        public bool Activo { get; set; }

        [ForeignKey("IdEquipo")]
        public virtual Equipo Equipo { get; set; }



        public Jugador()
        {

        }
        public Jugador(JugadorNuevoDTO jugador )
        {
            IdJugador = 0;
            Nombre = jugador.Nombre;
            Numero = jugador.Numero;
            IdEquipo = jugador.IdEquipo;
            Activo = true;
        }

    }
}
