using Denuncia.Negocio;
using MvcSiteMapProvider.Security;
using ServicioAutenticacion.Composite;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using System.Xml.Linq;

namespace Denuncia.Presentacion.MVC.Web.Autorizacion
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private int[] _accesosIds;
        private ServicioAutenticacionComposite _servicioComposite;

        public CustomAuthorizeAttribute(params int[] accesosIds)
        {
            _accesosIds = accesosIds;
            _servicioComposite = new ServicioAutenticacionComposite();
            setRoles();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                RedirectSSO(filterContext);
                return;
            }
            else
            {
                FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
                var refreshToken = IdentityUser.SESION_HASH_TOKEN;
                if (string.IsNullOrEmpty(refreshToken))
                {
                    RedirectSSO(filterContext);
                    return;
                }
                var token = _servicioComposite.ServicioAutenticacion.RefrescarTokenAcceso(refreshToken);
                IdentityUser.GeneraToken(token);
            }
            setRoles();
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Error/AcessDenied");
            }
        }

        private void setRoles()
        {
            var roles = new List<string>();
            var webSiteMapServicio = new WebSiteMapServicio();
            foreach (var acceso in _accesosIds)
            {
                roles.AddRange(webSiteMapServicio.ObtenerRolesAcceso(acceso));
            }
            Roles = string.Join(",", roles);
        }

        private void RedirectSSO(AuthorizationContext filterContext)
        {
            var servicioComposite = new ServicioAutenticacionComposite();
            var llamada = servicioComposite.ServicioAutenticacion.LlamarCliente();
            if (llamada != null)
            {
                IdentityUser.SESION_HASH_STATE = llamada.HashEstado;
                filterContext.Result = new RedirectResult(llamada.URL);
            }
        }

    }
}