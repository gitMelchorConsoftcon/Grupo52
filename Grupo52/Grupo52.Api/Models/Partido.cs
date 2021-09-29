using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo52.Api.Models
{
    [Table("Partidos")]  
    public class Partido
    {
        [Key] 
        public int IdPartido { get; set; }

        [Required]
        public DateTime fecha { get; set; }


        [Required]
        public int IdEquipoLocal { get; set; }

        [Required]
        public int IdEquipoVisitante { get; set; }

        [Required]
        public int GolLocal { get; set; }

        [Required]
        public int GolVisitante { get; set; }


        [ForeignKey("IdEquipoLocal")]
        public virtual Equipo EquipoLocal { get; set; }

        [ForeignKey("IdEquipoVisitante")]
        public virtual Equipo EquipoVisitante { get; set; }
    }
}
