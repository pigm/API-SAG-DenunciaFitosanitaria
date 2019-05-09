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
    public class DenunciaCategoriasController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/DenunciaCategorias
        public IQueryable<DenunciaCategoria> GetDenunciaCategorias()
        {
            return db.DenunciaCategorias;
        }

        // GET: api/DenunciaCategorias/5
        [ResponseType(typeof(DenunciaCategoria))]
        public IHttpActionResult GetDenunciaCategoria(int id)
        {
            DenunciaCategoria denunciaCategoria = db.DenunciaCategorias.Find(id);
            if (denunciaCategoria == null)
            {
                return NotFound();
            }

            return Ok(denunciaCategoria);
        }

        // PUT: api/DenunciaCategorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDenunciaCategoria(int id, DenunciaCategoria denunciaCategoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denunciaCategoria.idDenunciaCategoria)
            {
                return BadRequest();
            }

            db.Entry(denunciaCategoria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenunciaCategoriaExists(id))
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

        // POST: api/DenunciaCategorias
        [ResponseType(typeof(DenunciaCategoria))]
        public IHttpActionResult PostDenunciaCategoria(DenunciaCategoria denunciaCategoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DenunciaCategorias.Add(denunciaCategoria);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DenunciaCategoriaExists(denunciaCategoria.idDenunciaCategoria))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = denunciaCategoria.idDenunciaCategoria }, denunciaCategoria);
        }

        // DELETE: api/DenunciaCategorias/5
        [ResponseType(typeof(DenunciaCategoria))]
        public IHttpActionResult DeleteDenunciaCategoria(int id)
        {
            DenunciaCategoria denunciaCategoria = db.DenunciaCategorias.Find(id);
            if (denunciaCategoria == null)
            {
                return NotFound();
            }

            db.DenunciaCategorias.Remove(denunciaCategoria);
            db.SaveChanges();

            return Ok(denunciaCategoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DenunciaCategoriaExists(int id)
        {
            return db.DenunciaCategorias.Count(e => e.idDenunciaCategoria == id) > 0;
        }
    }
}