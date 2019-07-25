using EcoHand.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcoHand.Api.Controllers
{
    public class SecuenciasController : ApiController
    {
        private OperativeDbContext _dbContext = new OperativeDbContext();

        // GET: api/Secuencias
        public IHttpActionResult Get()
        {
            var secuencias = _dbContext.Secuencias.ToList();
            return Json(secuencias);
        }

        // GET: api/Secuencias/5
        public IHttpActionResult Get(int id)
        {
            var secuencia = _dbContext.Secuencias.Find(id);
            return Json(secuencia);
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
