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
    public class PathsController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/Paths
        public IQueryable<aspnet_Paths> Getaspnet_Paths()
        {
            return db.aspnet_Paths;
        }

        // GET: api/Paths/5
        [ResponseType(typeof(aspnet_Paths))]
        public IHttpActionResult Getaspnet_Paths(Guid id)
        {
            aspnet_Paths aspnet_Paths = db.aspnet_Paths.Find(id);
            if (aspnet_Paths == null)
            {
                return NotFound();
            }

            return Ok(aspnet_Paths);
        }

        // PUT: api/Paths/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_Paths(Guid id, aspnet_Paths aspnet_Paths)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_Paths.PathId)
            {
                return BadRequest();
            }

            db.Entry(aspnet_Paths).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_PathsExists(id))
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

        // POST: api/Paths
        [ResponseType(typeof(aspnet_Paths))]
        public IHttpActionResult Postaspnet_Paths(aspnet_Paths aspnet_Paths)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_Paths.Add(aspnet_Paths);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_PathsExists(aspnet_Paths.PathId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_Paths.PathId }, aspnet_Paths);
        }

        // DELETE: api/Paths/5
        [ResponseType(typeof(aspnet_Paths))]
        public IHttpActionResult Deleteaspnet_Paths(Guid id)
        {
            aspnet_Paths aspnet_Paths = db.aspnet_Paths.Find(id);
            if (aspnet_Paths == null)
            {
                return NotFound();
            }

            db.aspnet_Paths.Remove(aspnet_Paths);
            db.SaveChanges();

            return Ok(aspnet_Paths);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_PathsExists(Guid id)
        {
            return db.aspnet_Paths.Count(e => e.PathId == id) > 0;
        }
    }
}