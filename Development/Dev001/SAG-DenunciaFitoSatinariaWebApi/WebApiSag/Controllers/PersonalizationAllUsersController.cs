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
    public class PersonalizationAllUsersController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/PersonalizationAllUsers
        public IQueryable<aspnet_PersonalizationAllUsers> Getaspnet_PersonalizationAllUsers()
        {
            return db.aspnet_PersonalizationAllUsers;
        }

        // GET: api/PersonalizationAllUsers/5
        [ResponseType(typeof(aspnet_PersonalizationAllUsers))]
        public IHttpActionResult Getaspnet_PersonalizationAllUsers(Guid id)
        {
            aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers = db.aspnet_PersonalizationAllUsers.Find(id);
            if (aspnet_PersonalizationAllUsers == null)
            {
                return NotFound();
            }

            return Ok(aspnet_PersonalizationAllUsers);
        }

        // PUT: api/PersonalizationAllUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_PersonalizationAllUsers(Guid id, aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_PersonalizationAllUsers.PathId)
            {
                return BadRequest();
            }

            db.Entry(aspnet_PersonalizationAllUsers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_PersonalizationAllUsersExists(id))
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

        // POST: api/PersonalizationAllUsers
        [ResponseType(typeof(aspnet_PersonalizationAllUsers))]
        public IHttpActionResult Postaspnet_PersonalizationAllUsers(aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_PersonalizationAllUsers.Add(aspnet_PersonalizationAllUsers);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_PersonalizationAllUsersExists(aspnet_PersonalizationAllUsers.PathId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_PersonalizationAllUsers.PathId }, aspnet_PersonalizationAllUsers);
        }

        // DELETE: api/PersonalizationAllUsers/5
        [ResponseType(typeof(aspnet_PersonalizationAllUsers))]
        public IHttpActionResult Deleteaspnet_PersonalizationAllUsers(Guid id)
        {
            aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers = db.aspnet_PersonalizationAllUsers.Find(id);
            if (aspnet_PersonalizationAllUsers == null)
            {
                return NotFound();
            }

            db.aspnet_PersonalizationAllUsers.Remove(aspnet_PersonalizationAllUsers);
            db.SaveChanges();

            return Ok(aspnet_PersonalizationAllUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_PersonalizationAllUsersExists(Guid id)
        {
            return db.aspnet_PersonalizationAllUsers.Count(e => e.PathId == id) > 0;
        }
    }
}