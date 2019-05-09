using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApiSag.Constants;
using WebApiSag.Models;
using WebApiSag.Models.Response;
using WebApiSag.Request.User;
using WebApiSag.Security.Filters;
using WebApiSag.Utils;

namespace WebApiSag.Controllers
{
   // [ApiExplorerSettings(IgnoreApi = true)]
    public class TipoDenunciasController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(UsersController));
        private static DynamicResponse responseService = new DynamicResponse();
        /// <summary>
        /// Envia las TipoDenuncia de la app
        /// </summary>
        /// <remarks>
        /// Envia la lista de todas las TipoDenuncia
        /// (El método POST se utiliza para enviar una entidad a un recurso en específico, causando a menudo un cambio en el estado o efectos secundarios en el servidor.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: api/TipoDenuncias
        [JWTAuthenticationFilter]
        [Route("PostTipoDenuncia")]
          public DynamicResponse Post([FromBody][Required]TipoDenunciaReques data)
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
                        //var tipodenuncia = db.TipoDenuncia.Where(x => x.Estado == data.estado).ToList();
                        var tipodenuncia = from TipoDenuncia in db.TipoDenuncia
                                           where TipoDenuncia.Estado == data.estado
                                           select new
                                           {
                                               TipoDenuncia.IdTipoDenuncia,
                                               TipoDenuncia.Nombre,
                                               TipoDenuncia.Estado,
                                               TipoDenuncia.Incognito
                                           };

                        ResponseFormat.PrepareResponseSuccess(tipodenuncia, responseService, token);
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
        ////[JWTAuthenticationFilter]
        ////public DynamicResponse Post([FromBody][Required]LoginTipoDenuncia data)
        ////{
        ////    var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
        ////    try
        ////    {
        ////        if (data != null)
        ////        {
        ////            if (data.estado != false)
        ////            {
        ////                if (ModelState.IsValid)
        ////                {
        ////                    var auth = ControllerContext.Request.Headers.Authorization;
        ////                    var token = TokenUtils.GetToken(auth);
        ////                    //var tipodenuncia = db.TipoDenuncia.Where(x => x.IdTipoDenuncia == data.idtipodenuncia && x.Estado == data.estado).ToList();
        ////                    var tipodenuncia = from TipoDenuncia in db.TipoDenuncia where TipoDenuncia.IdTipoDenuncia == data.idtipodenuncia && TipoDenuncia.Estado == data.estado
        ////                                       select new
        ////                            {
        ////                                TipoDenuncia.IdTipoDenuncia,
        ////                                TipoDenuncia.Nombre,
        ////                                TipoDenuncia.Estado

        ////                            };
        ////                    ResponseFormat.PrepareResponseSuccess(tipodenuncia, responseService, token);
        ////                }
        ////                else
        ////                {
        ////                    Utils.ResponseFormat.PrepareResponseDataInError(responseService, ConfigurationManager.AppSettings["BadRequest"]);
        ////                    Logger.Error(path + " : " + PropertiesConstants.ERROR_DATA);
        ////                }
        ////            }
        ////            else
        ////            {
        ////                Utils.ResponseFormat.PrepareResponseDataInError(responseService, ConfigurationManager.AppSettings["BadRequest"]);
        ////                Logger.Error(path + " : " + PropertiesConstants.ERROR_DATA);
        ////            }
        ////        }
        ////        else
        ////        {
        ////            Utils.ResponseFormat.PrepareResponseDataInError(responseService, ConfigurationManager.AppSettings["BadRequest"]);
        ////            Logger.Error(path + " : " + PropertiesConstants.ERROR_DATA);
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Utils.ResponseFormat.PrepareResponseDataInError(responseService, ex.Message);
        ////        Logger.Error(path + " : " + ex.StackTrace);
        ////    }
        ////    return responseService;
        ////}

        //[ResponseType(typeof(TipoDenuncia))]
        //public IHttpActionResult PostTipoDenuncia(TipoDenuncia tipoDenuncia)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.TipoDenuncia.Add(tipoDenuncia);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = tipoDenuncia.IdTipoDenuncia }, tipoDenuncia);

        //}

        //// GET: api/TipoDenuncias
        //public IQueryable<TipoDenuncia> GetTipoDenuncias()
        //{
        //    return db.TipoDenuncia;
        //}

        //// GET: api/TipoDenuncias/5
        //[ResponseType(typeof(TipoDenuncia))]
        //public IHttpActionResult GetTipoDenuncia(int id)
        //{
        //    TipoDenuncia tipoDenuncia = db.TipoDenuncia.Find(id);
        //    if (tipoDenuncia == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tipoDenuncia);
        //}

        //// PUT: api/TipoDenuncias/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTipoDenuncia(int id, TipoDenuncia tipoDenuncia)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tipoDenuncia.IdTipoDenuncia)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tipoDenuncia).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TipoDenunciaExists(id))
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



        //// DELETE: api/TipoDenuncias/5
        //[ResponseType(typeof(TipoDenuncia))]
        //public IHttpActionResult DeleteTipoDenuncia(int id)
        //{
        //    TipoDenuncia tipoDenuncia = db.TipoDenuncia.Find(id);
        //    if (tipoDenuncia == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TipoDenuncia.Remove(tipoDenuncia);
        //    db.SaveChanges();

        //    return Ok(tipoDenuncia);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool TipoDenunciaExists(int id)
        //{
        //    return db.TipoDenuncia.Count(e => e.IdTipoDenuncia == id) > 0;
        //}
    }
}