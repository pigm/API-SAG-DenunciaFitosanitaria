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
    public class WebEvent_EventsController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/WebEvent_Events
        public IQueryable<aspnet_WebEvent_Events> Getaspnet_WebEvent_Events()
        {
            return db.aspnet_WebEvent_Events;
        }

        // GET: api/WebEvent_Events/5
        [ResponseType(typeof(aspnet_WebEvent_Events))]
        public IHttpActionResult Getaspnet_WebEvent_Events(string id)
        {
            aspnet_WebEvent_Events aspnet_WebEvent_Events = db.aspnet_WebEvent_Events.Find(id);
            if (aspnet_WebEvent_Events == null)
            {
                return NotFound();
            }

            return Ok(aspnet_WebEvent_Events);
        }

        // PUT: api/WebEvent_Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_WebEvent_Events(string id, aspnet_WebEvent_Events aspnet_WebEvent_Events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_WebEvent_Events.EventId)
            {
                return BadRequest();
            }

            db.Entry(aspnet_WebEvent_Events).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_WebEvent_EventsExists(id))
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

        // POST: api/WebEvent_Events
        [ResponseType(typeof(aspnet_WebEvent_Events))]
        public IHttpActionResult Postaspnet_WebEvent_Events(aspnet_WebEvent_Events aspnet_WebEvent_Events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_WebEvent_Events.Add(aspnet_WebEvent_Events);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_WebEvent_EventsExists(aspnet_WebEvent_Events.EventId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_WebEvent_Events.EventId }, aspnet_WebEvent_Events);
        }

        // DELETE: api/WebEvent_Events/5
        [ResponseType(typeof(aspnet_WebEvent_Events))]
        public IHttpActionResult Deleteaspnet_WebEvent_Events(string id)
        {
            aspnet_WebEvent_Events aspnet_WebEvent_Events = db.aspnet_WebEvent_Events.Find(id);
            if (aspnet_WebEvent_Events == null)
            {
                return NotFound();
            }

            db.aspnet_WebEvent_Events.Remove(aspnet_WebEvent_Events);
            db.SaveChanges();

            return Ok(aspnet_WebEvent_Events);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_WebEvent_EventsExists(string id)
        {
            return db.aspnet_WebEvent_Events.Count(e => e.EventId == id) > 0;
        }
    }
}