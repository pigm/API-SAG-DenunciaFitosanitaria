using Clases;
using ServicioAutenticacion.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace Denuncia.Presentacion.MVC.Web.Autorizacion
{
    public class IdentityUser
    {
        private const string SESION_HASH_STATE_NAME = "HASH_STATE";
        private const string SESION__HASH_TOKEN = "HASHTOKEN";
        public static string UserName { get { return HttpContext.Current.User.Identity.Name; } }

        public static bool IsAuthenticated { get { return HttpContext.Current.User.Identity.IsAuthenticated; } }

        public static string RolName
        {
            get
            {
                string role = Roles.GetRolesForUser(UserName).FirstOrDefault();
                if (string.IsNullOrEmpty(role))
                    return string.Empty;
                return role;
            }
        }

        public static bool ModificaDenuncia
        {
            get
            {
                return (bool)HttpContext.Current.Profile.GetPropertyValue("ModificaDenuncia");
            }
        }

        public static string SESION_HASH_STATE
        {
            get
            {
                string hashSesion = HttpContext.Current.Session[SESION_HASH_STATE_NAME] as string;
                return hashSesion;
            }
            set
            {
                HttpContext.Current.Session[SESION_HASH_STATE_NAME] = value;
            }
        }

        public static string SESION_HASH_TOKEN
        {
            get
            {
                string hashSesion = HttpContext.Current.Session[SESION__HASH_TOKEN] as string;
                return hashSesion;
            }
            set
            {
                HttpContext.Current.Session[SESION__HASH_TOKEN] = value;
            }
        }


        public static bool GeneraToken(ResultToken token)
        {
            var servicioComposite = new ServicioAutenticacionComposite();
            UserInfo usuario = servicioComposite.ServicioAutenticacion.ObtenerInformacionUsuario(token.access_token, token.token_type);
            if (usuario != null)
            {
                RefreshToken refrescar = servicioComposite.ServicioAutenticacion.GenerarRefreshToken(token.refresh_token, token.expires_in.ToString());
                var datetimeExpire = DateTime.Now.AddSeconds(int.Parse(refrescar.Expire));
                SESION_HASH_TOKEN = refrescar.Refresh;
                var authCookie = FormsAuthentication.GetAuthCookie(usuario.email, false);
                authCookie.Expires = datetimeExpire;
                //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                //FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, datetimeExpire, ticket.IsPersistent, userDataString);
                //authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                HttpContext.Current.Response.Cookies.Add(authCookie);
                return true;
            }
            return false;
        }

    }
}