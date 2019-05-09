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
    public class PersonalizationPerUserController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/PersonalizationPerUser
        public IQueryable<aspnet_PersonalizationPerUser> Getaspnet_PersonalizationPerUser()
        {
            return db.aspnet_PersonalizationPerUser;
        }

        // GET: api/PersonalizationPerUser/5
        [ResponseType(typeof(aspnet_PersonalizationPerUser))]
        public IHttpActionResult Getaspnet_PersonalizationPerUser(Guid id)
        {
            aspnet_PersonalizationPerUser aspnet_PersonalizationPerUser = db.aspnet_PersonalizationPerUser.Find(id);
            if (aspnet_PersonalizationPerUser == null)
            {
                return NotFound();
            }

            return Ok(aspnet_PersonalizationPerUser);
        }

        // PUT: api/PersonalizationPerUser/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_PersonalizationPerUser(Guid id, aspnet_PersonalizationPerUser aspnet_PersonalizationPerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_PersonalizationPerUser.Id)
            {
                return BadRequest();
            }

            db.Entry(aspnet_PersonalizationPerUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_PersonalizationPerUserExists(id))
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

        // POST: api/PersonalizationPerUser
        [ResponseType(typeof(aspnet_PersonalizationPerUser))]
        public IHttpActionResult Postaspnet_PersonalizationPerUser(aspnet_PersonalizationPerUser aspnet_PersonalizationPerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_PersonalizationPerUser.Add(aspnet_PersonalizationPerUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_PersonalizationPerUserExists(aspnet_PersonalizationPerUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_PersonalizationPerUser.Id }, aspnet_PersonalizationPerUser);
        }

        // DELETE: api/PersonalizationPerUser/5
        [ResponseType(typeof(aspnet_PersonalizationPerUser))]
        public IHttpActionResult Deleteaspnet_PersonalizationPerUser(Guid id)
        {
            aspnet_PersonalizationPerUser aspnet_PersonalizationPerUser = db.aspnet_PersonalizationPerUser.Find(id);
            if (aspnet_PersonalizationPerUser == null)
            {
                return NotFound();
            }

            db.aspnet_PersonalizationPerUser.Remove(aspnet_PersonalizationPerUser);
            db.SaveChanges();

            return Ok(aspnet_PersonalizationPerUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_PersonalizationPerUserExists(Guid id)
        {
            return db.aspnet_PersonalizationPerUser.Count(e => e.Id == id) > 0;
        }
    }
}