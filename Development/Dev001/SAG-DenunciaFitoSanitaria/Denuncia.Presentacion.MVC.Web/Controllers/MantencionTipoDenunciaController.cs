using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    [CustomAuthorize(3)]
    public class MantencionTipoDenunciaController : Controller
    {
        public ActionResult Index()
        {
            var mantencionTipoDenuncia = new MantencionTipoDenunciaViewModel();
            mantencionTipoDenuncia.ListarTipoDenuncia();
            return View(mantencionTipoDenuncia.ListaTipoDenuncia);
        }

        public ActionResult Nuevo()
        {
            TipoDenunciaModel tipoDenunciaModel = new TipoDenunciaModel();
            return PartialView("_Nuevo", tipoDenunciaModel);
        }

        [HttpPost]
        public ActionResult Crear(TipoDenunciaModel tipoDenunciaModel)
        {
            if (ModelState.IsValid)
            {
                var mantencionTipoDenuncia = new MantencionTipoDenunciaViewModel();
                mantencionTipoDenuncia.Agregar(tipoDenunciaModel);
                TempData["msg"] = "Tipo de Denuncia creado correctamente.";
                return Json(new { success = true });
            }
            return PartialView("_Nuevo", tipoDenunciaModel);
        }

        public ActionResult Editar(int idTipoDenuncia)
        {
            var mantencionTipoDenuncia = new MantencionTipoDenunciaViewModel();
            mantencionTipoDenuncia.ObtenerTipoDenuncia(idTipoDenuncia);
            mantencionTipoDenuncia.TipoDenunciaModel.EsNuevo = false;
            return PartialView("_Nuevo", mantencionTipoDenuncia.TipoDenunciaModel);
        }

        [HttpPost]
        public ActionResult Modificar(TipoDenunciaModel tipoDenunciaModel)
        {
            if (ModelState.IsValid)
            {
                var mantencionTipoDenuncia = new MantencionTipoDenunciaViewModel();
                mantencionTipoDenuncia.Modificar(tipoDenunciaModel);
                TempData["msg"] = "Tipo de Denuncia modificada correctamente.";
                return Json(new { success = true });
            }
            return PartialView("_Nuevo", tipoDenunciaModel);
        }
    }
}