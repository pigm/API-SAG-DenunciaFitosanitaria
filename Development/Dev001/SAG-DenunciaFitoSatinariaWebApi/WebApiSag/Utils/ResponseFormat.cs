using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using WebApiSag.Models.Response;
using WebApiSag.Models;

namespace WebApiSag.Utils
{
    public class ResponseFormat
    {
        private static ErrorResponse error = new ErrorResponse();
        private static HeaderResponse header = new HeaderResponse();
        private static BodyResponse response = new BodyResponse();
        private static int ERRORCODECOMMON = -1;
        private static BodyResponse bodyBlanc = new BodyResponse();
        private static ErrorResponse errorBlanc = new ErrorResponse();
        private static HeaderResponse headerBlanc = new HeaderResponse();

        /// <summary>
        /// Prepara error de datos de entrada
        /// </summary>
        /// <param name="responseService"></param>
        /// <param name="error"></param>
        /// <param name="description"></param>
        public static void PrepareResponseDataInError(DynamicResponse responseService, string description)
        {
            responseService.statusCode = ERRORCODECOMMON;
            error.errorCode = ERRORCODECOMMON;
            error.errorDescription = description;
            header.code = 400;
            header.description = ConfigurationManager.AppSettings["BadRequest"];
            header.token = "";
            responseService.header = header;
            responseService.error = error;
            responseService.response = bodyBlanc;
        }

        /// <summary>
        /// Prepara respuesta satisfactoria
        /// </summary>
        /// <param name="body"></param>
        /// <param name="responseService"></param>
        /// <param name="response"></param>
        public static void PrepareResponseSuccess(object body, DynamicResponse responseService, string token)
        {
            responseService.statusCode = 0;
            response.body = body;
            header.code = 200;
            header.description = ConfigurationManager.AppSettings["Success"];
            header.token = token;
            responseService.header = header;
            responseService.response = response;
            responseService.error = errorBlanc;
        }

        /// <summary>
        /// Prepara respuesta de error desde la componente
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorDescription"></param>
        /// <param name="responseService"></param>
        /// <param name="error"></param>
        public static void PrepareResponseError(int errorCode, string errorDescription, DynamicResponse responseService)
        {
            responseService.statusCode = ERRORCODECOMMON;
            error.errorCode = errorCode;
            error.errorDescription = errorDescription;
            responseService.error = error;
            header.code = 500;
            header.description = ConfigurationManager.AppSettings["ServerError"];
            header.token = "";
            responseService.header = header;
            responseService.response = bodyBlanc;
        }

        /// <summary>
        /// No autorizado
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorDescription"></param>
        /// <param name="responseService"></param>
        public static void PrepareResponseNoAuthorized(int errorCode, string errorDescription, DynamicResponse responseService)
        {
            responseService.statusCode = ERRORCODECOMMON;
            error.errorCode = errorCode;
            error.errorDescription = errorDescription;
            header.code = 401;
            header.description = ConfigurationManager.AppSettings["NoAutorizado"];
            header.token = "";
            responseService.header = header;
            responseService.error = error;
            responseService.response = bodyBlanc;
        }

    }
}