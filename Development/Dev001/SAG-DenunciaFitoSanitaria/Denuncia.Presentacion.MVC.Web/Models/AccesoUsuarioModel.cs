using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace Denuncia.Presentacion.MVC.Web.Models
{

    public class AccesoUsuarioModel
    {
        public string Controller { get; private set; }
        public string Action { get; private set; }

        public bool IsAuthenticated { get { return HttpContext.Current.User.Identity.IsAuthenticated; } }

        public bool GeneraPrimerIngreso()
        {
            var rolAccesosServicios = new WebSiteMapServicio();
            var roles = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name);
            if (roles.Count() == 0)
                return false;
            var rol = roles.First();
            var accesos = rolAccesosServicios.ObtenerAccesosxRol(rol).Where(acc => acc.url != "");
            if (accesos.Count() == 0)
                return false;
            
            var acceso = accesos.OrderBy(acc => acc.ID).First();
            var url = acceso.url.Split('/');
            if (url.Count() != 2)
                return false;

            Controller = url[0];
            Action = url[1];
            return true;
        }
    }
}