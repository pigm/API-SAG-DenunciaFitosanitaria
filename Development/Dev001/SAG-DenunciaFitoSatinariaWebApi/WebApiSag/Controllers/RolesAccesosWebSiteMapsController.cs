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
    public class RolesAccesosWebSiteMapsController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/RolesAccesosWebSiteMaps
        public IQueryable<RolesAccesosWebSiteMap> GetRolesAccesosWebSiteMaps()
        {
            return db.RolesAccesosWebSiteMap;
        }

        // GET: api/RolesAccesosWebSiteMaps/5
        [ResponseType(typeof(RolesAccesosWebSiteMap))]
        public IHttpActionResult GetRolesAccesosWebSiteMap(string id)
        {
            RolesAccesosWebSiteMap rolesAccesosWebSiteMap = db.RolesAccesosWebSiteMap.Find(id);
            if (rolesAccesosWebSiteMap == null)
            {
                return NotFound();
            }

            return Ok(rolesAccesosWebSiteMap);
        }

        // PUT: api/RolesAccesosWebSiteMaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRolesAccesosWebSiteMap(string id, RolesAccesosWebSiteMap rolesAccesosWebSiteMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rolesAccesosWebSiteMap.RoleName)
            {
                return BadRequest();
            }

            db.Entry(rolesAccesosWebSiteMap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesAccesosWebSiteMapExists(id))
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

        // POST: api/RolesAccesosWebSiteMaps
        [ResponseType(typeof(RolesAccesosWebSiteMap))]
        public IHttpActionResult PostRolesAccesosWebSiteMap(RolesAccesosWebSiteMap rolesAccesosWebSiteMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RolesAccesosWebSiteMap.Add(rolesAccesosWebSiteMap);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RolesAccesosWebSiteMapExists(rolesAccesosWebSiteMap.RoleName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rolesAccesosWebSiteMap.RoleName }, rolesAccesosWebSiteMap);
        }

        // DELETE: api/RolesAccesosWebSiteMaps/5
        [ResponseType(typeof(RolesAccesosWebSiteMap))]
        public IHttpActionResult DeleteRolesAccesosWebSiteMap(string id)
        {
            RolesAccesosWebSiteMap rolesAccesosWebSiteMap = db.RolesAccesosWebSiteMap.Find(id);
            if (rolesAccesosWebSiteMap == null)
            {
                return NotFound();
            }

            db.RolesAccesosWebSiteMap.Remove(rolesAccesosWebSiteMap);
            db.SaveChanges();

            return Ok(rolesAccesosWebSiteMap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolesAccesosWebSiteMapExists(string id)
        {
            return db.RolesAccesosWebSiteMap.Count(e => e.RoleName == id) > 0;
        }
    }
}