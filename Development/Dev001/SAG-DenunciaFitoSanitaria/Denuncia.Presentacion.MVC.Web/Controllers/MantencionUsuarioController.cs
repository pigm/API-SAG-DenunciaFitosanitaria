using Denuncia.Negocio;
using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    [CustomAuthorize(6)]
    public class MantencionUsuarioController : Controller
    {
        public ActionResult Index()
        {

            var mantencionUsuarioViewModel = new MantencionUsuarioViewModel();
            mantencionUsuarioViewModel.ObtenerUsuarios();
            var mantencionSubCategoria = new MantencionSubCategoriaViewModel();
            mantencionSubCategoria.ListarSubCategoria();
            return View(mantencionUsuarioViewModel.ListaUsuarioModel);
        }

        public ActionResult Nuevo()
        {
            var usuarioModel = new UsuarioModel();
            return PartialView("_Nuevo", usuarioModel);
        }

        public ActionResult Editar(Guid idUsuario)
        {
            var mantencionUsuarioViewModel = new MantencionUsuarioViewModel();
            mantencionUsuarioViewModel.ObtenerUsuario(idUsuario);
            mantencionUsuarioViewModel.UsuarioModel.EsNuevo = false;
            return PartialView("_Nuevo", mantencionUsuarioViewModel.UsuarioModel);
        }

        [HttpPost]
        public ActionResult Crear(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                MembershipUser membershipUser = Membership.GetUser(usuarioModel.Email);
                if (membershipUser != null)
                {
                    ModelState.AddModelError("UserName", "Usuario ya existe.");
                    return PartialView("_Nuevo", usuarioModel);
                }

                var mantencionUsuarioViewModel = new MantencionUsuarioViewModel();
                mantencionUsuarioViewModel.UsuarioModel = usuarioModel;
                mantencionUsuarioViewModel.Agregar();
                TempData["msg"] = "Usuario creado correctamente.";
                return Json(new { success = true });
            }
            return PartialView("_Nuevo", usuarioModel);
        }

        [HttpPost]
        public ActionResult Modificar(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var mantencionUsuarioViewModel = new MantencionUsuarioViewModel();
                mantencionUsuarioViewModel.UsuarioModel = usuarioModel;
                mantencionUsuarioViewModel.Modificar();
                TempData["msg"] = "Usuario modificado correctamente.";
                return Json(new { success = true });
            }
            return PartialView("_Nuevo", usuarioModel);
        }

        [HttpPost]
        public ActionResult Eliminar(Guid idUsuario)
        {
            var mantencionUsuarioViewModel = new MantencionUsuarioViewModel();
            mantencionUsuarioViewModel.Eliminar(idUsuario);
            TempData["msg"] = "Usuario eliminado correctamente.";
            return Json(new { success = true });
        }
    }
}