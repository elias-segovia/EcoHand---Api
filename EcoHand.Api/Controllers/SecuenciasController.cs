using EcoHand.Api.DTO_In;
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

        public IHttpActionResult Get(string secuenciaName)
        {
            var sec = _dbContext.Secuencias.Where(x => x.Nombre == secuenciaName).FirstOrDefault();

            return Json(sec);
        }


        // POST: api/Secuencias
        public HttpResponseMessage Post([FromBody]Secuencia secuencia)
        {
            try
            {
                secuencia.FechaCreacion = DateTime.Now;
                secuencia.FechaModificacion = DateTime.Now;
                _dbContext.Secuencias.Add(secuencia);

                _dbContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK,secuencia.ID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,ex);
            }
        }

        // PUT: api/Secuencias/5
        public HttpResponseMessage Put( [FromBody]Secuencia secuencia)
        {
            try
            {
                var target = _dbContext.Secuencias.Find(secuencia.ID);

                if (target == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Secuencia con id=" + secuencia.ID + "no encontrada");
                }

                target.FechaModificacion = DateTime.Now;
                target.Descripcion = secuencia.Descripcion;
                target.Nombre = secuencia.Nombre;
                target.CodigoEjecutable = secuencia.CodigoEjecutable;
                target.CodigoEstructura = secuencia.CodigoEstructura;
                _dbContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, target);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Secuencias/5
        public IHttpActionResult Delete(int id)
        {
            var secu = _dbContext.Secuencias.Find(id);

            _dbContext.Secuencias.Remove(secu);

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
