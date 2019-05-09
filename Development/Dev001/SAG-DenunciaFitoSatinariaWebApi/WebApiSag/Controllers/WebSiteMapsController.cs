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
    public class WebSiteMapsController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();

        // GET: api/WebSiteMaps
        public IQueryable<WebSiteMap> GetWebSiteMaps()
        {
            return db.WebSiteMap;
        }

        // GET: api/WebSiteMaps/5
        [ResponseType(typeof(WebSiteMap))]
        public IHttpActionResult GetWebSiteMap(int id)
        {
            WebSiteMap webSiteMap = db.WebSiteMap.Find(id);
            if (webSiteMap == null)
            {
                return NotFound();
            }

            return Ok(webSiteMap);
        }

        // PUT: api/WebSiteMaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWebSiteMap(int id, WebSiteMap webSiteMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != webSiteMap.ID)
            {
                return BadRequest();
            }

            db.Entry(webSiteMap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebSiteMapExists(id))
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

        // POST: api/WebSiteMaps
        [ResponseType(typeof(WebSiteMap))]
        public IHttpActionResult PostWebSiteMap(WebSiteMap webSiteMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WebSiteMap.Add(webSiteMap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = webSiteMap.ID }, webSiteMap);
        }

        // DELETE: api/WebSiteMaps/5
        [ResponseType(typeof(WebSiteMap))]
        public IHttpActionResult DeleteWebSiteMap(int id)
        {
            WebSiteMap webSiteMap = db.WebSiteMap.Find(id);
            if (webSiteMap == null)
            {
                return NotFound();
            }

            db.WebSiteMap.Remove(webSiteMap);
            db.SaveChanges();

            return Ok(webSiteMap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WebSiteMapExists(int id)
        {
            return db.WebSiteMap.Count(e => e.ID == id) > 0;
        }
    }
}