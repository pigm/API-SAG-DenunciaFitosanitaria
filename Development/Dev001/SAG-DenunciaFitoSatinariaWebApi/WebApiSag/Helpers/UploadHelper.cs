using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApiSag.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="filename"></param>
        /// <param name="response"></param>
        /// <param name="path"></param>
        public static void UploadFile(HttpRequestMessage request, string filename, HttpResponseMessage response, string path)
        {
            var task = request.Content.ReadAsStreamAsync();
            task.Wait();
            Stream requestStream = task.Result;

            try
            {
                Stream fileStream = File.Create(path + filename);
                requestStream.CopyTo(fileStream);
                fileStream.Close();
                requestStream.Close();
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (IOException)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}