using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSag.Constants;
using WebApiSag.Helpers;
using WebApiSag.Security.Filters;

namespace WebApiSag.Controllers
{
    ////Prueba IC
    [RoutePrefix("api/Audio")]
    public class AudioController : ApiController
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(AudioController));
        /// <summary>
        /// Upload image from phone
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [JWTAuthenticationFilter]
        [Route("UploadAudio")]
        public HttpResponseMessage Post([FromUri]string filename)
        {
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                if (filename != null)
                {
                    UploadHelper.UploadFile(this.Request, filename, response, ConfigurationManager.AppSettings["ServerPathAudio"]);
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    Logger.Error(path + " : " + PropertiesConstants.ERROR_DATA);
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                Logger.Error(path + " : " + ex.StackTrace);
            }
            return response;
        }
    }
}
