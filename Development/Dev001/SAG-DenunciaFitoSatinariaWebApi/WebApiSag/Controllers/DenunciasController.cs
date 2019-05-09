using Newtonsoft.Json;
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
    /// <summary>
    /// Api Controller para Denuncia
    /// </summary>
    [RoutePrefix("api/Denuncia")]
    
    public class DenunciasController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(UsersController));
        private static DynamicResponse responseService = new DynamicResponse();
        /// <summary>
        /// Envia las Denuncias de la app
        /// </summary>
        /// <remarks>
        /// Envia la lista de todas los Denuncias
        /// (El método POST se utiliza para enviar una entidad a un recurso en específico, causando a menudo un cambio en el estado o efectos secundarios en el servidor.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: api/Denuncias
        [JWTAuthenticationFilter]
        [Route("AllDenuncia")]       
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
                        var denuncias = db.Denuncia.Where(x => x.IdEstadoDenuncia == data.idestadodenuncia).ToList();
                        ResponseFormat.PrepareResponseSuccess(denuncias, responseService, token);
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
        [JWTAuthenticationFilter]
        public DynamicResponse Post([FromBody][Required]LoginDenuncia data)
        {        
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            try
            {
                if (data != null)
                {
                    if (data.idestadodenuncia != 0)
                    {
                        if (ModelState.IsValid)
                        {
                            var auth = ControllerContext.Request.Headers.Authorization;
                            var token = TokenUtils.GetToken(auth);
                            var denuncias = db.Denuncia.Where(x => x.IdDenuncia == data.IdDenuncia && x.IdEstadoDenuncia == data.idestadodenuncia).ToList();
                            ResponseFormat.PrepareResponseSuccess(denuncias, responseService, token);
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

        /// <summary>
        /// Inserta las Denuncias de la app
        /// </summary>
        /// <remarks>
        /// Inserta nuevos datos a la lista de Denuncias (crear un nuevo registro)
        /// (El modo Insert crear un nuevo registro.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns> 
        [JWTAuthenticationFilter]
        [Route("InsertDenuncia")]
        public DynamicResponse Post([FromBody][Required]InsertDenuncia data)
        {
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            try
            {
                if (data != null)
                {
                    if (data.idestadodenuncia != 0)
                    {
                        if (ModelState.IsValid)
                        {
                            var auth = ControllerContext.Request.Headers.Authorization;
                            var token = TokenUtils.GetToken(auth);

                            string json = JsonConvert.SerializeObject(data);
                            Denuncia pDt = JsonConvert.DeserializeObject<Denuncia>(json);
                            db.Denuncia.Add(pDt);
                            db.SaveChanges();
                            var id = pDt.IdDenuncia;
                            ResponseFormat.PrepareResponseSuccess(id, responseService, token);                            
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

        [JWTAuthenticationFilter]
        [Route("UpdatetDenuncia")]
        public DynamicResponse Post([FromBody][Required]DenunciaRequest data)
        {
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            try
            {
                if (data != null)
                {
                    if (data.iddenuncia != 0)
                    {
                        if (ModelState.IsValid)
                        {
                            var auth = ControllerContext.Request.Headers.Authorization;
                            var token = TokenUtils.GetToken(auth);

                            var query = (from x in db.Denuncia
                                         where x.IdDenuncia == data.iddenuncia
                                         select x).FirstOrDefault();
                            query.CorreoContacto = data.CorreoContacto;
                            query.TelefonoContacto = data.TelefonoContacto;

                             db.SaveChanges();

                            ResponseFormat.PrepareResponseSuccess(true, responseService, token);
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
        private bool DenunciaExists(int id)
        {
            return db.Denuncia.Count(e => e.IdDenuncia == id) > 0;
        }






        //[Route("AddDenuncia")]
        //public IHttpActionResult PostDenuncia(Denuncia denuncia)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Denuncia.Add(denuncia);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = denuncia.IdDenuncia }, denuncia);
        //}

        ///// <summary>
        ///// Lista las Denuncias de la app
        ///// </summary>
        ///// <remarks>
        ///// Obtiene lista de todas los Denuncias
        ///// (El método GET  solicita una representación de un recurso específico. Las peticiones que usan el método GET sólo deben recuperar datos.)
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <returns></returns>
        ///// 
        //[Route("Denuncias")]
        //// GET: api/Denuncias
        //public IQueryable<Denuncia> GetDenuncias()
        //{
        //    return db.Denuncia;
        //}

        //// GET: api/Denuncias/5
        //[ResponseType(typeof(Denuncia))]
        //public IHttpActionResult GetDenuncia(int id)
        //{
        //    Denuncia denuncia = db.Denuncia.Find(id);
        //    if (denuncia == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(denuncia);
        //}
        ///// <summary>
        ///// Remplaza las Denuncias de la app
        ///// </summary>
        ///// <remarks>
        ///// Remplaza la lista de todas los Denuncias
        ///// (El modo PUT reemplaza todas las representaciones actuales del recurso de destino con la carga útil de la petición.)
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <returns></returns>        
        //// PUT: api/Denuncias/5


        ///// <summary>
        ///// Elimina las Denuncias de la app
        ///// </summary>
        ///// <remarks>
        ///// Elimina la lista de todas los Denuncias
        ///// (El método DELETE borra un recurso en específico.)
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //// DELETE: api/Denuncias/5
        //[Route("DeleteDenuncia")]
        //[ResponseType(typeof(Denuncia))]
        //public IHttpActionResult DeleteDenuncia(int id)
        //{
        //    Denuncia denuncia = db.Denuncia.Find(id);
        //    if (denuncia == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Denuncia.Remove(denuncia);
        //    db.SaveChanges();

        //    return Ok(denuncia);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


    }
}