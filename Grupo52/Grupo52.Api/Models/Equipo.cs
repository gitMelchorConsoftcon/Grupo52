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
        [Required]
        [MaxLength(35)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(200)]
        public string Logotipo { get; set; }

        [MaxLength(40)]
        public string Ciudad { get; set; }

        [Required]
        [Range(0,200000)]
        public int Capacidad { get; set; }
    }
}


//DataAnotation: Sirver para configurar los modelos 
//[]
//[Tabla] 
//[Column] 
//[Key] : Llave primaria
//[Required] : Campo obligatorios
//[Range] :Limita el numero de valores numericos


