using System.Collections.Generic;

namespace Grupo52.Api.Interfaces
{
    public interface IRepositorioGenerico<T>
    {
        List<T> Listar();
        T Buscar(int id);
        T Guardar(T obj);
        T Modificar(int id, T obj);
        T Borrar(int id);
    }
}
