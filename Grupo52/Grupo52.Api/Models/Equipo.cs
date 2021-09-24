using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo52.Api.Models
{
    [Table("Equipos")]
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }

        [Column(name: "NombreEquipo")]
        [Required(ErrorMessage ="El {0} es un campo requerido ")]
        [MaxLength(35,ErrorMessage ="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El {0} es un campo requerido")]
        [MaxLength(200)]
        public string Logotipo { get; set; }

        [MaxLength(40)]
        public string Ciudad { get; set; }

        [Required]
        [Range(0,200000)]
        public int Capacidad { get; set; }


        [MaxLength(60)]
        public string NombreEstadio { get; set; }

        [Required]
        public bool Activo { get; set; }


        public virtual  List<Jugador>  Jugadores{ get; set; }

    }
}


//DataAnotation: Sirver para configurar los modelos 
//[]
//[Tabla] 
//[Column] 
//[Key] : Llave primaria
//[Required] : Campo obligatorios
//[Range] :Limita el numero de valores numericos


