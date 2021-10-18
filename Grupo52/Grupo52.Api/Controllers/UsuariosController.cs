using Grupo52.Api.DTOS;
using Grupo52.Api.Interfaces;
using Grupo52.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Grupo52.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public ISoccerUOW _bd;
        private IConfiguration _config;

        public UsuariosController(ISoccerUOW bd, IConfiguration config)
        {
            _bd = bd;
            _config = config;
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


        [HttpPost]
        [Route("Login/")]
        public IActionResult Login (UserLogin user)
        {

            var datos = _bd.Usuarios.Login(user.Usuario, user.Password);

            if (datos == null)
                return Unauthorized("Usuario o contraseña incorrecta...");


            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,datos.IdUsuario.ToString() ),
                new Claim(ClaimTypes.Name,datos.Nombre)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriopcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = credenciales
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriopcion);


            return Ok(

                new
                {
                    usuario = new UsuarioDto(datos),
                    token = tokenHandler.WriteToken(token)
                }

                ) ;

        }



    }
}
