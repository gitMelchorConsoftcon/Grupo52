using Grupo52.Api.DTOS;
using Grupo52.Api.Interfaces;
using Grupo52.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public ISoccerUOW _bd;

        public UsuariosController(ISoccerUOW bd)
        {
            _bd = bd;
        }


        [HttpGet] // Sirve para obtener informacion del servidor
        public IActionResult Get()
        {
            var lista = new List<UsuarioDto>();

            foreach (var item in _bd.Usuarios.Listar())
                lista.Add(new UsuarioDto(item));

            return Ok(lista);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUsuario(int id)
        {
            Usuario usuario = _bd.Usuarios.Buscar(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok( new UsuarioDto( usuario));
        }

        [HttpPost]  // sirve para guardar informacion
        public IActionResult GuardarUsuario(UsuarioNuevoDto usuario)
        {
            var usuarior = _bd.Usuarios.Guardar(new Usuario( usuario));
            return Ok( new UsuarioDto( usuarior));
        }


        [HttpPut] // sirve para modificar informacion
        [Route("{id}")]
        public IActionResult ModificarUsuario(int id, UsuarioNuevoDto usuario)
        {
           var usuarior = _bd.Usuarios.Modificar(id,  new Usuario( usuario));
            return Ok(new UsuarioDto( usuarior));
        }


        [HttpDelete]   // sirver para borrar
        [Route("{id}")]
        public IActionResult BorrarUsuario(int id)
        {

            Usuario borrar = _bd.Usuarios.Borrar(id);
            return Ok(new UsuarioDto( borrar));
        }

    }
}
