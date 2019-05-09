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
    /// Api Controllers para SubCategorias
    /// </summary>
    [RoutePrefix("api/SubCategorias")]
    public class SubCategoriasController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(UsersController));
        private static DynamicResponse responseService = new DynamicResponse();
        /// <summary>
        /// Envia las Subcategorias de la app
        /// </summary>
        /// <remarks>
        /// Envia la lista de todas las Subcategorias
        /// (El método POST se utiliza para enviar una entidad a un recurso en específico, causando a menudo un cambio en el estado o efectos secundarios en el servidor.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        [JWTAuthenticationFilter]
        [Route("PostSubCategoria")]
        // POST: api/SubCategorias
        //[ResponseType(typeof(SubCategoria))]

        public DynamicResponse Post([FromBody][Required]SubCategoriaRequest data)
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
                        var subcategoria = db.SubCategoria.Where(x => x.Estado == data.estado).ToList();
                        ResponseFormat.PrepareResponseSuccess(subcategoria, responseService, token);
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
        public DynamicResponse Post([FromBody][Required]LoginSubCategoria data)
        {
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            try
            {
                if (data != null)
                {
                    if (data.estado != false)
                    {
                        if (ModelState.IsValid)
                        {
                            var auth = ControllerContext.Request.Headers.Authorization;
                            var token = TokenUtils.GetToken(auth);
                            var subcategoria = db.SubCategoria.Where(x => x.IdSubCategoria == data.idsubcategoria && x.Estado == data.estado).ToList();
                            ResponseFormat.PrepareResponseSuccess(subcategoria, responseService, token);
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


        //public IHttpActionResult PostSubCategoria(SubCategoria subCategoria)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.SubCategoria.Add(subCategoria);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = subCategoria.IdSubCategoria }, subCategoria);
        //}

        ///// <summary>
        ///// Lista las SubCategorias de la App
        ///// </summary>
        /////<remarks>
        ///// Obtiene lista de todas las SubCategorias 
        ///// (El método GET  solicita una representación de un recurso específico. Las peticiones que usan el método GET sólo deben recuperar datos.)
        /////</remarks>
        /////<param name="data"></param>
        ///// <returns></returns>
        //[Route("GetSubCategorias")]
        //// GET: api/SubCategorias
        //public IQueryable<SubCategoria> GetSubCategorias()
        //{
        //    return db.SubCategoria;
        //}

        //// GET: api/SubCategorias/5
        //[ResponseType(typeof(SubCategoria))]
        //public IHttpActionResult GetSubCategoria(int id)
        //{
        //    SubCategoria subCategoria = db.SubCategoria.Find(id);
        //    if (subCategoria == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(subCategoria);
        //}
        ///// <summary>
        ///// Remplaza las Subcategorias de la app
        ///// </summary>
        ///// <remarks>
        ///// Remplaza la lista de todas las Subcategorias
        ///// (El modo PUT reemplaza todas las representaciones actuales del recurso de destino con la carga útil de la petición.)
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //[Route("PutSubCategoria")]
        //// PUT: api/SubCategorias/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutSubCategoria(int id, SubCategoria subCategoria)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != subCategoria.IdSubCategoria)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(subCategoria).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubCategoriaExists(id))
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

        ///// <summary>
        ///// Elimina las SubCategoria de la app
        ///// </summary>
        ///// <remarks>
        ///// Elimina la lista de todas las SubCategoria
        ///// (El método DELETE borra un recurso en específico.)
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //[Route("DeleteSubCategoria")]
        //// DELETE: api/SubCategorias/5
        //[ResponseType(typeof(SubCategoria))]
        //public IHttpActionResult DeleteSubCategoria(int id)
        //{
        //    SubCategoria subCategoria = db.SubCategoria.Find(id);
        //    if (subCategoria == null)
        //    {
        //        return NotFound();
        //    }

        //    db.SubCategoria.Remove(subCategoria);
        //    db.SaveChanges();

        //    return Ok(subCategoria);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool SubCategoriaExists(int id)
        //{
        //    return db.SubCategoria.Count(e => e.IdSubCategoria == id) > 0;
        //}
    }
}