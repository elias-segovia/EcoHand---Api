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
            try
            {
                gesto.FechaCreacion = DateTime.Now;
                gesto.FechaModificacion = DateTime.Now;
                _dbContext.Gestos.Add(gesto);

                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Gestos/5
        public HttpResponseMessage Put([FromBody]Gesto gesto)
        {
            try
            {
                var target = _dbContext.Gestos.Find(gesto.ID);

                if (target == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Gesto con id=" + gesto.ID + "no encontrado");
                }

                target.FechaModificacion = DateTime.Now;
                target.Descripcion = gesto.Descripcion;
                target.Nombre = gesto.Nombre;
                target.PosAnular = gesto.PosAnular;
                target.Posindice = gesto.Posindice;
                target.PosMayor = gesto.PosMayor;
                target.PosMeñique = gesto.PosMeñique;
                target.PosPulgar = gesto.PosPulgar;


                _dbContext.SaveChanges();

               return  Request.CreateResponse(HttpStatusCode.OK, target);
            }
            catch (Exception ex)
            {
               return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Gestos/5
        public IHttpActionResult Delete(int id)
        {

            var gesto = _dbContext.Gestos.Find(id);

            _dbContext.Gestos.Remove(gesto);

            _dbContext.SaveChanges();

            return Ok();

        }
    }
}
