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
    //Application controller 
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApplicationsController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/Applications
        public IQueryable<aspnet_Applications> Getaspnet_Applications()
        {
            return db.aspnet_Applications;
        }

        // GET: api/Applications/5
        [ResponseType(typeof(aspnet_Applications))]
        public IHttpActionResult Getaspnet_Applications(Guid id)
        {
            aspnet_Applications aspnet_Applications = db.aspnet_Applications.Find(id);
            if (aspnet_Applications == null)
            {
                return NotFound();
            }

            return Ok(aspnet_Applications);
        }

        // PUT: api/Applications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_Applications(Guid id, aspnet_Applications aspnet_Applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_Applications.ApplicationId)
            {
                return BadRequest();
            }

            db.Entry(aspnet_Applications).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_ApplicationsExists(id))
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

        // POST: api/Applications
        [ResponseType(typeof(aspnet_Applications))]
        public IHttpActionResult Postaspnet_Applications(aspnet_Applications aspnet_Applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_Applications.Add(aspnet_Applications);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_ApplicationsExists(aspnet_Applications.ApplicationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_Applications.ApplicationId }, aspnet_Applications);
        }

        // DELETE: api/Applications/5
        [ResponseType(typeof(aspnet_Applications))]
        public IHttpActionResult Deleteaspnet_Applications(Guid id)
        {
            aspnet_Applications aspnet_Applications = db.aspnet_Applications.Find(id);
            if (aspnet_Applications == null)
            {
                return NotFound();
            }

            db.aspnet_Applications.Remove(aspnet_Applications);
            db.SaveChanges();

            return Ok(aspnet_Applications);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_ApplicationsExists(Guid id)
        {
            return db.aspnet_Applications.Count(e => e.ApplicationId == id) > 0;
        }
    }
}