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
    public class MembershipController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/Membership
        public IQueryable<aspnet_Membership> Getaspnet_Membership()
        {
            return db.aspnet_Membership;
        }

        // GET: api/Membership/5
        [ResponseType(typeof(aspnet_Membership))]
        public IHttpActionResult Getaspnet_Membership(Guid id)
        {
            aspnet_Membership aspnet_Membership = db.aspnet_Membership.Find(id);
            if (aspnet_Membership == null)
            {
                return NotFound();
            }

            return Ok(aspnet_Membership);
        }

        // PUT: api/Membership/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_Membership(Guid id, aspnet_Membership aspnet_Membership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_Membership.UserId)
            {
                return BadRequest();
            }

            db.Entry(aspnet_Membership).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_MembershipExists(id))
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

        // POST: api/Membership
        [ResponseType(typeof(aspnet_Membership))]
        public IHttpActionResult Postaspnet_Membership(aspnet_Membership aspnet_Membership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_Membership.Add(aspnet_Membership);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_MembershipExists(aspnet_Membership.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_Membership.UserId }, aspnet_Membership);
        }

        // DELETE: api/Membership/5
        [ResponseType(typeof(aspnet_Membership))]
        public IHttpActionResult Deleteaspnet_Membership(Guid id)
        {
            aspnet_Membership aspnet_Membership = db.aspnet_Membership.Find(id);
            if (aspnet_Membership == null)
            {
                return NotFound();
            }

            db.aspnet_Membership.Remove(aspnet_Membership);
            db.SaveChanges();

            return Ok(aspnet_Membership);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_MembershipExists(Guid id)
        {
            return db.aspnet_Membership.Count(e => e.UserId == id) > 0;
        }
    }
}