using EcoHand.Api.DTO_In;
using EcoHand.Api.DTO_Out;
using EcoHand.Api.Models;
using EcoHand.Data;
using EcoHand.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace EcoHand.Api.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        private OperativeDbContext _dbContext = new OperativeDbContext();

        // GET: api/Usuarios
        [HttpGet]
        [Route("Users")]
        public IHttpActionResult Get()
        {
            try
            {
                var usuario = _dbContext.Usuarios.ToList();
                return Ok(usuario);

            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
          
        }

        // GET: api/Usuarios/1
        [HttpGet]
        [Route("User/{id}")]
        public IHttpActionResult Get(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            return Ok(usuario);
        }

        
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login([FromBody] DTO_In_Usuario usuario)
        {
            try
            {
                if (_dbContext.Usuarios.Any(x => x.Username == usuario.Username && x.Contraseña == usuario.Contraseña))
                {
                    var user = new Usuario();
                    user.Username = usuario.Username;
                    user.Contraseña = usuario.Contraseña;
                    return Ok(new DTO_Out_Id(user.ID));
                }
                else
                {
                    return BadRequest(ErrorCodes.USUARIO_INEXISTENTE);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/Usuarios
        [HttpPost]
        [Route("User")]
        public IHttpActionResult Post([FromBody] DTO_In_Usuario usuario)
        {
            try
            {

                if (!_dbContext.Usuarios.Any(x => x.Username == usuario.Username))
                {
                    var user = new Usuario();
                    user.Username = usuario.Username;
                    user.Email = usuario.Email;
                    user.Contraseña = usuario.Contraseña;
                    user.FechaCreacion = DateTime.Today;
                    _dbContext.Usuarios.Add(user);
                    _dbContext.SaveChanges();

                    return Ok(new DTO_Out_Id(user.ID));
                }
                else
                {
                    return BadRequest(ErrorCodes.USUARIO_EXISTENTE);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
