using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiSag.Constants;
using WebApiSag.Models;
using WebApiSag.Models.Response;
using WebApiSag.Request.User;
using WebApiSag.Security.Filters;
using WebApiSag.Utils;

namespace WebApiSag.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class EstadoDenunciasController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(UsersController));
        private static DynamicResponse responseService = new DynamicResponse();
        /// <summary>
        /// Envia las Estado Denuncia de la app
        /// </summary>
        /// <remarks>
        /// Envia la lista de todas los Estado Denuncia
        /// (El método POST se utiliza para enviar una entidad a un recurso en específico, causando a menudo un cambio en el estado o efectos secundarios en el servidor.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: api/Denuncias
        [JWTAuthenticationFilter]
        // POST: api/EstadoDenuncias
        //[ResponseType(typeof(EstadoDenuncia))]
        [Route ("PostEstadoDenuncia")]
        public DynamicResponse Post([FromBody][Required]EstadoDenunciaRequest data)
        {
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            try
            {
                if (data != null)
                {
                    if (ModelState.IsValid)
                    {
                        var auth = ControllerContext.Request.Headers.Authorization;
                        var token = TokenUtils.GetToken(auth);
                        var estadodenuncia = db.EstadoDenuncia.Where(x => x.IdEstadoDenuncia == data.idestadodenuncia).ToList();
                        ResponseFormat.PrepareResponseSuccess(estadodenuncia, responseService, token);
                    }
                    else
                    {
                        Utils.ResponseFormat.PrepareResponseDataInError(responseService, ConfigurationManager.AppSettings["BadRequest"]);
                        Logger.Error(path + " : " + PropertiesConstants.ERROR_DATA);
                    }
                }
                else
                {
                    Utils.ResponseFormat.PrepareResponseDataInError(responseService, ConfigurationManager.AppSettings["BadRequest"]);
                    Logger.Error(path + " : " + PropertiesConstants.ERROR_DATA);
                }
            }
            catch (Exception ex)
            {
                Utils.ResponseFormat.PrepareResponseDataInError(responseService, ex.Message);
                Logger.Error(path + " : " + ex.StackTrace);
            }
            return responseService;
        }

        //public IHttpActionResult PostEstadoDenuncia(EstadoDenuncia estadoDenuncia)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.EstadoDenuncia.Add(estadoDenuncia);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = estadoDenuncia.IdEstadoDenuncia }, estadoDenuncia);
        //}
        //// GET: api/EstadoDenuncias
        //public IQueryable<EstadoDenuncia> GetEstadoDenuncias()
        //{
        //    return db.EstadoDenuncia;
        //}

        //// GET: api/EstadoDenuncias/5
        //[ResponseType(typeof(EstadoDenuncia))]
        //public IHttpActionResult GetEstadoDenuncia(int id)
        //{
        //    EstadoDenuncia estadoDenuncia = db.EstadoDenuncia.Find(id);
        //    if (estadoDenuncia == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(estadoDenuncia);
        //}

        //// PUT: api/EstadoDenuncias/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutEstadoDenuncia(int id, EstadoDenuncia estadoDenuncia)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != estadoDenuncia.IdEstadoDenuncia)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(estadoDenuncia).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EstadoDenunciaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}



        //// DELETE: api/EstadoDenuncias/5
        //[ResponseType(typeof(EstadoDenuncia))]
        //public IHttpActionResult DeleteEstadoDenuncia(int id)
        //{
        //    EstadoDenuncia estadoDenuncia = db.EstadoDenuncia.Find(id);
        //    if (estadoDenuncia == null)
        //    {
        //        return NotFound();
        //    }

        //    db.EstadoDenuncia.Remove(estadoDenuncia);
        //    db.SaveChanges();

        //    return Ok(estadoDenuncia);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool EstadoDenunciaExists(int id)
        //{
        //    return db.EstadoDenuncia.Count(e => e.IdEstadoDenuncia == id) > 0;
        //}
    }
}