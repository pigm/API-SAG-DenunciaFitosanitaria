using Clases;
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


    [Autorizacion.CustomAuthorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var accesoUsuario = new AccesoUsuarioModel();
            if (accesoUsuario.GeneraPrimerIngreso())
                return RedirectToAction(accesoUsuario.Action, accesoUsuario.Controller);
            return RedirectToAction("AcessDenied", "Error");
        }
                
    }
}
