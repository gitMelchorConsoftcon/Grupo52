using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo52.Api.DTOS
{
    public class UsuarioNuevoDto
    {


        public UsuarioNuevoDto()
        {

        }

        [Required]
        [MaxLength(90)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(30)]
        public String UserName { get; set; }

        [Required]
        [MaxLength(300)]
        public String Password { get; set; }

    }
}
