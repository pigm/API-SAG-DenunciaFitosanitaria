using Clases;
using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using ServicioAutenticacion.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult LoginLocal()
        {
            var model = new LoginViewModel();
            return View("Login", model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = Membership.ValidateUser(model.UserName, model.Password);
            if (result)
            {
                var authCookie = FormsAuthentication.GetAuthCookie(model.UserName, false);
                Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("UserName", " ");
            ModelState.AddModelError("Password", "Ingrese un usuario y contraseña válido.");

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login(string state, string code)
        {
            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(state))
            {
                string hashSesion = IdentityUser.SESION_HASH_STATE;
                if (state.Equals(hashSesion))
                {
                    var servicioComposite = new ServicioAutenticacionComposite();
                    ResultToken token = servicioComposite.ServicioAutenticacion.ObtenerTokenAcceso(state, code);
                    if (token != null)
                    {
                        IdentityUser.GeneraToken(token);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            var servicioComposite = new ServicioAutenticacionComposite();
            var UrlCerrarSession = servicioComposite.ServicioAutenticacion.CerrarSesion();
            FormsAuthentication.SignOut();
            return Redirect(UrlCerrarSession);
        }

    }
}