using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denuncia.Presentacion.MVC.Web.Funciones
{
    public static class CurrentContext
    {
        public static string UserName()
        {
            return string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) ? "Anonymous" : HttpContext.Current.User.Identity.Name;
        }
    }
}