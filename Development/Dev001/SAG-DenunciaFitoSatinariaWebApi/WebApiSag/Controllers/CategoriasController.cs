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
    /// Api Controller para Categoria
    /// </summary>
    [RoutePrefix("api/Categoria")]
    public class CategoriasController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(UsersController));
        private static DynamicResponse responseService = new DynamicResponse();
        /// <summary>
        /// Envia las categorias de la app
        /// </summary>
        /// <remarks>
        /// Envia la lista de todas las categorias
        /// (El método POST se utiliza para enviar una entidad a un recurso en específico, causando a menudo un cambio en el estado o efectos secundarios en el servidor.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        // POST: api/Categorias/AllCategories
        [JWTAuthenticationFilter]
        [Route("AllCategories")]
        public DynamicResponse Post([FromBody][Required]CategoriaRequest data)
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
                        var categorias = db.Categoria.Where(x => x.Estado == data.estado).ToList();
                        ResponseFormat.PrepareResponseSuccess(categorias, responseService, token);
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
        public DynamicResponse Post([FromBody][Required]LoginCategoria data)
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
                            var categorias = db.Categoria.Where(x => x.IdCategoria == data.idCategoria && x.Estado == data.estado).ToList();
                            ResponseFormat.PrepareResponseSuccess(categorias, responseService, token);
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
        //****Inicio Comentario Get
        ///// <summary>
        ///// Lista las categorias de la app
        ///// </summary>
        ///// <remarks>
        ///// Obtiene lista de todas las categorias
        ///// (El método GET  solicita una representación de un recurso específico. Las peticiones que usan el método GET sólo deben recuperar datos.)
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <returns></returns>
        ///// 
        //[Route("Categorias")]
        //public IQueryable<Categoria> GetCategorias()
        //{
        //    return db.Categoria;
        //}

        //// GET: api/Categorias/5
        //[ResponseType(typeof(Categoria))]
        //public IHttpActionResult GetCategoria(int id)
        //{
        //    Categoria categoria = db.Categoria.Find(id);
        //    if (categoria == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(categoria);
        //}
        //****Fin comentario Get
        //****Inicio comentario Put
        ///// <summary>
        ///// Remplaza las categorias de la app
        ///// </summary>
        ///// <remarks>
        ///// Remplaza la lista de todas las categorias
        ///// (El modo PUT reemplaza todas las representaciones actuales del recurso de destino con la carga útil de la petición.)
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <returns></returns>
        ///// 
        //// PUT: api/Categorias/5
        //[Route("PutCategoria")]

        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCategoria(int id, Categoria categoria)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != categoria.IdCategoria)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(categoria).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoriaExists(id))
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
        //****Fin comentario Put
        //****Inicio comentario Delete
        ///// <summary>
        ///// Elimina las categorias de la app
        ///// </summary>
        ///// <remarks>
        ///// Elimina la lista de todas las categorias
        ///// (El método DELETE borra un recurso en específico.)
        ///// </remarks>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //// DELETE: api/Categorias/5
        //[Route("DeleteCategoria")]
        //[ResponseType(typeof(Categoria))]
        //public IHttpActionResult DeleteCategoria(int id)
        //{
        //    Categoria categoria = db.Categoria.Find(id);
        //    if (categoria == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Categoria.Remove(categoria);
        //    db.SaveChanges();

        //    return Ok(categoria);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CategoriaExists(int id)
        //{
        //    return db.Categoria.Count(e => e.IdCategoria == id) > 0;
        //}
        //****Fin comentario Delete
    }
}