using Grupo52.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Grupo52.Api.Data
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T :class
    {
        private readonly SoccerContext _bd;
        private readonly DbSet<T> Entidad;

        public RepositorioGenerico(SoccerContext bd)
        {
            _bd = bd;
            Entidad = _bd.Set<T>();
        }


        public List<T> Listar()
        {
            return Entidad.ToList();
        }


        public T Buscar(int id)
        {

            return Entidad.Find(id);
        }


        public T Guardar(T obj)
        {

            _bd.Add(obj);
            _bd.SaveChanges();
            return obj;
        }


        public T Modificar(int id , T obj)
        {
            //var modificar = Entidad.Find(id);

            //modificar = obj;

            _bd.Entry(obj).State = EntityState.Modified;
            _bd.SaveChanges();
            return obj;

        }

        public T Borrar(int id)
        {
            var borrar = Entidad.Find(id);

            _bd.Remove(borrar);
            _bd.SaveChanges();
            return borrar;
        }


    }
}
