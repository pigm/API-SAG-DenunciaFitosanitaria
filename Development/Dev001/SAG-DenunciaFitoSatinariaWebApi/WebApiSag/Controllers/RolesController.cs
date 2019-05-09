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
    /// <summary>
    /// Api Controller para Denuncia
    /// </summary>
    [RoutePrefix("api/Roles")]
    public class RolesController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();
        /// <summary>
        /// Lista los Roles de la app
        /// </summary>
        /// <remarks>
        /// Obtiene lista de todos los Roles
        /// (El método GET  solicita una representación de un recurso específico. Las peticiones que usan el método GET sólo deben recuperar datos.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        [Route("Getaspnet_Roles")]
        // GET: api/Roles
        public IQueryable<aspnet_Roles> Getaspnet_Roles()
        {
            return db.aspnet_Roles;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(aspnet_Roles))]
        public IHttpActionResult Getaspnet_Roles(string id)
        {
            aspnet_Roles aspnet_Roles = db.aspnet_Roles.Find(id);
            if (aspnet_Roles == null)
            {
                return NotFound();
            }

            return Ok(aspnet_Roles);
        }
        /// <summary>
        /// Remplaza los Roles de la app
        /// </summary>
        /// <remarks>
        /// Remplaza la lista de todos los Roles
        /// (El modo PUT reemplaza todas las representaciones actuales del recurso de destino con la carga útil de la petición.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>        
        [Route("Putaspnet_Roles")]
        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_Roles(string id, aspnet_Roles aspnet_Roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_Roles.RoleId)
            {
                return BadRequest();
            }

            db.Entry(aspnet_Roles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_RolesExists(id))
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
        /// <summary>
        /// Envia las Roles de la app
        /// </summary>
        /// <remarks>
        /// Envia la lista de todos los Roles
        /// (El método POST se utiliza para enviar una entidad a un recurso en específico, causando a menudo un cambio en el estado o efectos secundarios en el servidor.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("Postaspnet_Roles")]
        // POST: api/Roles
        [ResponseType(typeof(aspnet_Roles))]
        public IHttpActionResult Postaspnet_Roles(aspnet_Roles aspnet_Roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_Roles.Add(aspnet_Roles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_RolesExists(aspnet_Roles.RoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_Roles.RoleId }, aspnet_Roles);
        }
        /// <summary>
        /// Elimina los Roles de la app
        /// </summary>
        /// <remarks>
        /// Elimina la lista de todos los Roles
        /// (El método DELETE borra un recurso en específico.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("Deleteaspnet_Roles")]
        // DELETE: api/Roles/5
        [ResponseType(typeof(aspnet_Roles))]
        public IHttpActionResult Deleteaspnet_Roles(string id)
        {
            aspnet_Roles aspnet_Roles = db.aspnet_Roles.Find(id);
            if (aspnet_Roles == null)
            {
                return NotFound();
            }

            db.aspnet_Roles.Remove(aspnet_Roles);
            db.SaveChanges();

            return Ok(aspnet_Roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_RolesExists(string id)
        {
            return db.aspnet_Roles.Count(e => e.RoleId == id) > 0;
        }
    }
}