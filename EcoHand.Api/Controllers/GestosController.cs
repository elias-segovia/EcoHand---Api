using EcoHand.Data;
using EcoHand.Data.Models;
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
            return Json(gestos);
           
        }


        // GET: api/Gestos/5
        public IHttpActionResult Get(int id)
        {
            var gesto = _dbContext.Gestos.Find(id);
            return Json(gesto);
        }

        public IHttpActionResult GetByUserId(int UserId)
        {
            var gestos = _dbContext.Gestos.Where(x => x.UsuarioID == UserId).ToList();
            return Json(gestos);
        }



        // POST: api/Gestos
        public object Post([FromBody]Gesto gesto)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                new { gesto = gesto });

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
