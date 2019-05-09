using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    [CustomAuthorize(7)]
    public class MantencionRolController : Controller
    {
        public ActionResult Index()
        {
            var mantencionRolViewModel = new MantencionRolViewModel();
            mantencionRolViewModel.ObtenerRoles();
            return View(mantencionRolViewModel.ListaRoles);
        }

        public ActionResult Nuevo()
        {
            var rolModel = new RolModel();
            rolModel.EsNuevo = true;
            return PartialView("_Nuevo", rolModel);
        }

        public ActionResult Editar(string rolName)
        {
            var mantencionRolViewModel = new MantencionRolViewModel();
            mantencionRolViewModel.ObtenerRol(rolName);
            mantencionRolViewModel.Rol.EsNuevo = false;
            mantencionRolViewModel.Rol.SelectJsTree();
            return PartialView("_Nuevo", mantencionRolViewModel.Rol);
        }

        [HttpPost]
        public ActionResult Crear(RolModel rolModel)
        {
            if (!ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(rolModel.Acceso))
                  
                    rolModel.SelectJsTree();
                rolModel.EsNuevo = true;
                return PartialView("_Nuevo", rolModel);
            }
            var mantencionRolViewModel = new MantencionRolViewModel();
            mantencionRolViewModel.Rol = rolModel;
            mantencionRolViewModel.Agregar();
            TempData["msg"] = "Rol creado correctamente.";
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult Modificar(RolModel rolModel)
        {
            if (!ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(rolModel.Acceso))
                    rolModel.SelectJsTree();
                return PartialView("_Nuevo", rolModel);
            }
            var mantencionRolViewModel = new MantencionRolViewModel();
            mantencionRolViewModel.Rol = rolModel;
            mantencionRolViewModel.Modificar();
            TempData["msg"] = "Rol modificado correctamente.";
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult Eliminar(string rol)
        {
            var mantencionRolViewModel = new MantencionRolViewModel();
            bool eliminado = mantencionRolViewModel.Eliminar(rol);
            if (eliminado)
            {
                TempData["msg"] = "Rol eliminado correctamente.";
                return Json(new { success = true });
            }
            else
                return Json(new { success = false });
        }
    }
}