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
    public class SchemaVersionsController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/SchemaVersions
        public IQueryable<aspnet_SchemaVersions> Getaspnet_SchemaVersions()
        {
            return db.aspnet_SchemaVersions;
        }

        // GET: api/SchemaVersions/5
        [ResponseType(typeof(aspnet_SchemaVersions))]
        public IHttpActionResult Getaspnet_SchemaVersions(string id)
        {
            aspnet_SchemaVersions aspnet_SchemaVersions = db.aspnet_SchemaVersions.Find(id);
            if (aspnet_SchemaVersions == null)
            {
                return NotFound();
            }

            return Ok(aspnet_SchemaVersions);
        }

        // PUT: api/SchemaVersions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_SchemaVersions(string id, aspnet_SchemaVersions aspnet_SchemaVersions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_SchemaVersions.Feature)
            {
                return BadRequest();
            }

            db.Entry(aspnet_SchemaVersions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_SchemaVersionsExists(id))
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

        // POST: api/SchemaVersions
        [ResponseType(typeof(aspnet_SchemaVersions))]
        public IHttpActionResult Postaspnet_SchemaVersions(aspnet_SchemaVersions aspnet_SchemaVersions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_SchemaVersions.Add(aspnet_SchemaVersions);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_SchemaVersionsExists(aspnet_SchemaVersions.Feature))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_SchemaVersions.Feature }, aspnet_SchemaVersions);
        }

        // DELETE: api/SchemaVersions/5
        [ResponseType(typeof(aspnet_SchemaVersions))]
        public IHttpActionResult Deleteaspnet_SchemaVersions(string id)
        {
            aspnet_SchemaVersions aspnet_SchemaVersions = db.aspnet_SchemaVersions.Find(id);
            if (aspnet_SchemaVersions == null)
            {
                return NotFound();
            }

            db.aspnet_SchemaVersions.Remove(aspnet_SchemaVersions);
            db.SaveChanges();

            return Ok(aspnet_SchemaVersions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_SchemaVersionsExists(string id)
        {
            return db.aspnet_SchemaVersions.Count(e => e.Feature == id) > 0;
        }
    }
}