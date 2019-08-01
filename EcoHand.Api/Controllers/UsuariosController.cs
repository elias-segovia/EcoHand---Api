using EcoHand.Api.DTO_In;
using EcoHand.Api.DTO_Out;
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
    public class UsuariosController : ApiController
    {
        private OperativeDbContext _dbContext = new OperativeDbContext();

        // GET: api/Usuarios
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
        public IHttpActionResult Get(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            return Json(usuario);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] DTO_In_Usuario usuario)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuarios
        //[HttpPost]
        //public IHttpActionResult Post([FromBody] string username, string email)
        //{
        //    try
        //    {
        //        var usuario = new Usuario();
        //        _dbContext.Usuarios.Add(usuario);
        //        _dbContext.SaveChanges();

        //        return Json(new { result = "ok" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { result = "error" });
        //    }
        //}


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
