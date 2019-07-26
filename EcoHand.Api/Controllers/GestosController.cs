using EcoHand.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcoHand.Api.Controllers
{
    public class GestosController : ApiController
    {
        private OperativeDbContext _dbContext = new OperativeDbContext();

        // GET: api/Gestos
        public IHttpActionResult Get()
        {
            var gestos = _dbContext.Gestos.ToList();
            return Ok(gestos);
        }

        // GET: api/Gestos/5
        public IHttpActionResult Get(int id)
        {
            var gesto = _dbContext.Gestos.Find(id);
            return Json(gesto);
        }

        // POST: api/Gestos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Gestos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gestos/5
        public void Delete(int id)
        {
        }
    }
}
