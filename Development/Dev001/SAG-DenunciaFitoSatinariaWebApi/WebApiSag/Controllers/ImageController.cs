using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiSag.Constants;
using WebApiSag.Helpers;
using WebApiSag.Models.Response;
using WebApiSag.Request.Image;
using WebApiSag.Security.Filters;
using WebApiSag.Utils;

namespace WebApiSag.Controllers
{
    /// <summary>
    /// Controller para procesar imagenes
    /// </summary>
    [RoutePrefix("api/Image")]
    public class ImageController : ApiController
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(ImageController));
        private static DynamicResponse responseService = new DynamicResponse();

        [JWTAuthenticationFilter]
        [Route("GetImage")]
        public async Task<DynamicResponse> Post([FromBody][Required]ImageRequest data)
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
                        var image = "";
                        switch (data.formato)
                        {
                            case 1:
                                image = await ResponseFormat.GetImageAsBase64Url(ConfigurationManager.AppSettings["ServerImagePath"] + data.url.Replace("~", ""));
                                break;
                        }
                        ResponseFormat.PrepareResponseSuccess(image, responseService, token);
                    }
                    else
                    {
                        ResponseFormat.PrepareResponseDataInError(responseService, ConfigurationManager.AppSettings["BadRequest"]);
                        Logger.Error(path + " : " + PropertiesConstants.ERROR_DATA);
                    }
                }
                else
                {
                    ResponseFormat.PrepareResponseDataInError(responseService, ConfigurationManager.AppSettings["BadRequest"]);
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
        /// Upload image from phone
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [JWTAuthenticationFilter]
        [Route("UploadImage")]
        public HttpResponseMessage Post([FromUri]string filename)
        {
            var path = ControllerContext.Request.GetRouteData().Route.RouteTemplate;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                if (filename != null)
                {
                    UploadHelper.UploadFile(this.Request,filename, response, ConfigurationManager.AppSettings["ServerPathImage"]);
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
