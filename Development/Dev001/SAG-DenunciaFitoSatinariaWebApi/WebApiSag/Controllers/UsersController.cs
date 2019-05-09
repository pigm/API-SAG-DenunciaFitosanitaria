using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApiSag.Models;
using WebApiSag.Constants;
using WebApiSag.Models.Response;
using WebApiSag.Security.Authentication;
using WebApiSag.Security.Filters;
using WebApiSag.Utils;
using WebApiSag.Request;
using WebApiSag.Request.User;
using System.ComponentModel.DataAnnotations;
//Yamato
namespace WebApiSag.Controllers
{
    /// <summary>
    /// Api Controller para Usuario
    /// </summary>
    [RoutePrefix("api/User")]
    public class UsersController : ApiController
    {
        private dbDenunciaFitoSanitariaEntities db = new dbDenunciaFitoSanitariaEntities();      
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(UsersController));
        private static DynamicResponse responseService = new DynamicResponse();
        /// <summary>
        /// Login de usuario (Envia los Usuarios de la app)
        /// </summary>
        /// /// <remarks>
        /// Envia la lista de todos los Usuarios
        /// (El método POST se utiliza para enviar una entidad a un recurso en específico, causando a menudo un cambio en el estado o efectos secundarios en el servidor.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>        
        [Route("Login")]
        public DynamicResponse Post([FromBody][Required]LoginRequest data)
        {
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            try
            {
                if (data != null)
                {
                    if (ModelState.IsValid)
                    {
                        var exist = db.ApiToken.Where(x => x.ApiTokenName == data.user && x.ApiTokenPass == data.password && x.ApiEstado == 1).Any();
                        Logger.Info(path + " : " + PropertiesConstants.DATA_IN + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(data));
                        if (exist)
                        {
                            AuthenticationModule authentication = new AuthenticationModule();
                            string token = authentication.GenerateTokenForUser(data.user, 1);
                            Utils.ResponseFormat.PrepareResponseSuccess(new object() { }, responseService, token);
                        }
                        else
                        {
                            Utils.ResponseFormat.PrepareResponseNoAuthorized(-1, ConfigurationManager.AppSettings["NoAutorizado"], responseService);
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

            Logger.Info(path + " : " + PropertiesConstants.DATA_OUT + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(responseService));
            return responseService;
        }

        /// <summary>
        /// Get User Baskets (Lista los Usuarios de la app)
        /// </summary>        
        /// <remarks>
        /// Obtiene lista de todos los Usuarios
        /// (El método GET  solicita una representación de un recurso específico. Las peticiones que usan el método GET sólo deben recuperar datos.)
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        [JWTAuthenticationFilter]
        [Route("UserBaskets")]
        public DynamicResponse Post([FromBody]UserBasketRequest data)
        {
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            try
            {
                if (data != null)
                {
                    var auth = ControllerContext.Request.Headers.Authorization;
                    var token = TokenUtils.GetToken(auth);
                    Logger.Info(path + " : " + PropertiesConstants.DATA_IN + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(data));
                    Utils.ResponseFormat.PrepareResponseSuccess(new object() { }, responseService, token);

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

            Logger.Info(path + " : " + PropertiesConstants.DATA_OUT + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(responseService));
            return responseService;
        }
    }
}