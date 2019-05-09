using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiSag.Models;

namespace WebApiSag.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SubCategoria_ImagenesController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/SubCategoria_Imagenes
        public IQueryable<SubCategoria_Imagenes> GetSubCategoria_Imagenes()
        {
            return db.SubCategoria_Imagenes;
        }

        // GET: api/SubCategoria_Imagenes/5
        [ResponseType(typeof(SubCategoria_Imagenes))]
        public IHttpActionResult GetSubCategoria_Imagenes(int id)
        {
            SubCategoria_Imagenes subCategoria_Imagenes = db.SubCategoria_Imagenes.Find(id);
            if (subCategoria_Imagenes == null)
            {
                return NotFound();
            }

            return Ok(subCategoria_Imagenes);
        }

        // PUT: api/SubCategoria_Imagenes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubCategoria_Imagenes(int id, SubCategoria_Imagenes subCategoria_Imagenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subCategoria_Imagenes.IdSubCategoria)
            {
                return BadRequest();
            }

            db.Entry(subCategoria_Imagenes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoria_ImagenesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SubCategoria_Imagenes
        [ResponseType(typeof(SubCategoria_Imagenes))]
        public IHttpActionResult PostSubCategoria_Imagenes(SubCategoria_Imagenes subCategoria_Imagenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCategoria_Imagenes.Add(subCategoria_Imagenes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SubCategoria_ImagenesExists(subCategoria_Imagenes.IdSubCategoria))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subCategoria_Imagenes.IdSubCategoria }, subCategoria_Imagenes);
        }

        // DELETE: api/SubCategoria_Imagenes/5
        [ResponseType(typeof(SubCategoria_Imagenes))]
        public IHttpActionResult DeleteSubCategoria_Imagenes(int id)
        {
            SubCategoria_Imagenes subCategoria_Imagenes = db.SubCategoria_Imagenes.Find(id);
            if (subCategoria_Imagenes == null)
            {
                return NotFound();
            }

            db.SubCategoria_Imagenes.Remove(subCategoria_Imagenes);
            db.SaveChanges();

            return Ok(subCategoria_Imagenes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoria_ImagenesExists(int id)
        {
            return db.SubCategoria_Imagenes.Count(e => e.IdSubCategoria == id) > 0;
        }
    }
}