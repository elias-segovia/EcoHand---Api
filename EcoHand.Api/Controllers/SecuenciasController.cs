using EcoHand.Api.DTO_In;
using EcoHand.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcoHand.Api.Controllers
{
    [RoutePrefix("api/Secuencias")]
    public class SecuenciasController : ApiController
    {
        private OperativeDbContext _dbContext = new OperativeDbContext();

        // GET: api/Secuencias
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var secuencias = _dbContext.Secuencias.ToList();
            return Ok(secuencias);
        }

        // GET: api/Secuencias/5
        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var secuencia = _dbContext.Secuencias.Find(id);
            return Ok(secuencia);
        }

        // GET: api/Secuencias/5
        [HttpPost]
        [Route("Secuencias")]
        public IHttpActionResult GetSecuencias([FromBody] DTO_In_Usuario usuario)
        {
            var user = _dbContext.Usuarios.Where(x => x.Username == usuario.Username).First();
            var secuencias = _dbContext.Secuencias.Where(y => y.UsuarioID == user.ID).ToList();
            return Ok(secuencias);
        }

        // POST: api/Secuencias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Secuencias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Secuencias/5
        public void Delete(int id)
        {
        }
    }
}
