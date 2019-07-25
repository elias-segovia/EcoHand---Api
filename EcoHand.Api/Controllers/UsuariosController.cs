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
            var usuarios = _dbContext.Usuarios.ToList();
            return Json(usuarios);
        }

        // GET: api/Usuarios/1
        public IHttpActionResult Get(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            return Json(usuario);
        }

        // POST: api/Usuarios
        [HttpPost]
        public IHttpActionResult Post([FromBody] string username, string email)
        {
            try
            {
                var usuario = new Usuario();
                _dbContext.Usuarios.Add(usuario);
                _dbContext.SaveChanges();

                return Json(new { result = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error" });
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
