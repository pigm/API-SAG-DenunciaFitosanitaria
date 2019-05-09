using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApiSag.Utils
{
    public class TokenUtils
    {
        /// <summary>
        /// Obtiene el Token del metodo dentro del contexto actual
        /// </summary>
        /// <returns></returns>
        public static string GetToken(AuthenticationHeaderValue auth)
        {
            var token = auth.Parameter;
            if (token == null)
            {
                token = auth.Scheme;
            }

            return token;
        }
    }
}