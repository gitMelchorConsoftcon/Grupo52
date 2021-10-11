using Grupo52.Api.DTOS;
using Grupo52.Api.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo52.Api.Models
{
    [Table("Usuarios")]
    public class Usuario
    {

        public Usuario()
        {

        }

        public Usuario(UsuarioNuevoDto nuevo)
        {
            this.Nombre = nuevo.Nombre;
            this.UserName = nuevo.UserName;
        
            this.Password = nuevo.Password;
            this.Rol = EnumRol.Usuario;
        }

        [Key]
        public int IdUsuario { get; set; }
        
        [Required]
        [MaxLength(90)]
        public string Nombre { get; set; }
        
        [Required]
        [MaxLength(30)]
        public String UserName { get; set; }

        [Required]
        [MaxLength(300)]
        public String Password { get; set; }
        
        [Required]
        public EnumRol Rol { get; set; }

    }
}
