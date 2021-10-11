using Grupo52.Api.Models;
using Grupo52.Api.Models.Enums;

namespace Grupo52.Api.DTOS
{
    public class UsuarioDto
    {

        public UsuarioDto()
        {

        }

        public UsuarioDto(Usuario usuario )
        {
            this.IdUsuario = usuario.IdUsuario;
            this.Nombre = usuario.Nombre;
            this.Rol = usuario.Rol;

        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public EnumRol Rol { get; set; }
    }
}
