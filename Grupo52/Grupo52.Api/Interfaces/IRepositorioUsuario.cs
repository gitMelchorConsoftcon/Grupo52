using Grupo52.Api.Models;

namespace Grupo52.Api.Interfaces
{
    public interface IRepositorioUsuario :IRepositorioGenerico<Usuario>
    {
       new  Usuario Guardar(Usuario obj);

        Usuario Login(string usuario, string password);
    }
}
