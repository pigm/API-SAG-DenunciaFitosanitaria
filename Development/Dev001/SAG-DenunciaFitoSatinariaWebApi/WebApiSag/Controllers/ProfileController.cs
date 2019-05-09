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
    public class ProfileController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/Profile
        public IQueryable<aspnet_Profile> Getaspnet_Profile()
        {
            return db.aspnet_Profile;
        }

        // GET: api/Profile/5
        [ResponseType(typeof(aspnet_Profile))]
        public IHttpActionResult Getaspnet_Profile(Guid id)
        {
            aspnet_Profile aspnet_Profile = db.aspnet_Profile.Find(id);
            if (aspnet_Profile == null)
            {
                return NotFound();
            }

            return Ok(aspnet_Profile);
        }

        // PUT: api/Profile/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_Profile(Guid id, aspnet_Profile aspnet_Profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_Profile.UserId)
            {
                return BadRequest();
            }

            db.Entry(aspnet_Profile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_ProfileExists(id))
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

        // POST: api/Profile
        [ResponseType(typeof(aspnet_Profile))]
        public IHttpActionResult Postaspnet_Profile(aspnet_Profile aspnet_Profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_Profile.Add(aspnet_Profile);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_ProfileExists(aspnet_Profile.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_Profile.UserId }, aspnet_Profile);
        }

        // DELETE: api/Profile/5
        [ResponseType(typeof(aspnet_Profile))]
        public IHttpActionResult Deleteaspnet_Profile(Guid id)
        {
            aspnet_Profile aspnet_Profile = db.aspnet_Profile.Find(id);
            if (aspnet_Profile == null)
            {
                return NotFound();
            }

            db.aspnet_Profile.Remove(aspnet_Profile);
            db.SaveChanges();

            return Ok(aspnet_Profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_ProfileExists(Guid id)
        {
            return db.aspnet_Profile.Count(e => e.UserId == id) > 0;
        }
    }
}