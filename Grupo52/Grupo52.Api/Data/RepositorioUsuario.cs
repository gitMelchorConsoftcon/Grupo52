using Grupo52.Api.Interfaces;
using Grupo52.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Grupo52.Api.Data
{
    public class RepositorioUsuario : IRepositorioUsuario

    {
        private readonly SoccerContext _bd;


        public RepositorioUsuario(SoccerContext bd)
        {
            _bd = bd;

        }


        public List<Usuario> Listar()
        {
            return _bd.Usuarios.ToList();
        }


        public Usuario Buscar(int id)
        {

            return _bd.Usuarios.Find(id);
        }


        public Usuario Guardar(Usuario obj)
        {

            obj.Password = Encriptar(obj.Password);

            _bd.Add(obj);
            _bd.SaveChanges();
            return obj;
        }


        public Usuario Modificar(int id, Usuario obj)
        {
            //var modificar = Entidad.Find(id);

            //modificar = obj;

            _bd.Entry(obj).State = EntityState.Modified;
            _bd.SaveChanges();
            return obj;

        }

        public Usuario Borrar(int id)
        {
            var borrar = _bd.Usuarios.Find(id);

            _bd.Remove(borrar);
            _bd.SaveChanges();
            return borrar;
        }

        private readonly int SaltSize = 16;
        private readonly int Iterations = 10368;
        private readonly int KeySize = 32;

        private string Encriptar (string password)
        {
            using (Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(
                          password,
                          SaltSize,
                          Iterations
                          ))
            {
                string key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                string salt = Convert.ToBase64String(algorithm.Salt);

                return $"{Iterations}.{salt}.{key}" ;
            }        
        }


        private bool Chek(string hash, string password)
        {
            string[] partes = hash.Split(".");

            if (partes.Length!=3)
            {
                return false;
            }

            int iteractions = Convert.ToInt32(partes[0]);
            byte[] salt = Convert.FromBase64String(partes[1]);
            byte[] key = Convert.FromBase64String(partes[2]);

            using (Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                iteractions
                ))
            {
                byte[] keyToCheck = algorithm.GetBytes(KeySize);
                return keyToCheck.SequenceEqual(key);
             }
        }

        public Usuario Login(string usuario, string password)
        {
            throw new NotImplementedException();
        }
    }
}
