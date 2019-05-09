using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    [CustomAuthorize(5)]
    public class MantencionSubCategoriaController : Controller
    {
        public ActionResult Index()
        {
            var mantencionSubCategoria = new MantencionSubCategoriaViewModel();
            mantencionSubCategoria.ListarSubCategoriaMantenedor();
            return View(mantencionSubCategoria.ListaSubCategoria);
        }

        public ActionResult Nuevo()
        {
            SubCategoriaModel tipoInsectoModel = new SubCategoriaModel();
            return PartialView("_Nuevo", tipoInsectoModel);
        }

        public ActionResult Editar(int idSubCategoria)
        {
            var mantencionSubCategoria = new MantencionSubCategoriaViewModel();
            mantencionSubCategoria.Obtener(idSubCategoria);
            mantencionSubCategoria.SubCategoriaModel.EsNuevo = false;
            return PartialView("_Nuevo", mantencionSubCategoria.SubCategoriaModel);
        }

        [HttpPost]
        public ActionResult Crear(SubCategoriaModel subCategoriaModel)
        {
            if (ModelState.IsValid)
            {
                if (subCategoriaModel.FotoImagen != null)
                {
                    var mantencionSubCategoria = new MantencionSubCategoriaViewModel();
                    mantencionSubCategoria.Agregar(subCategoriaModel);
                    TempData["msg"] = "Sub-Categoría creado correctamente.";
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("FotoImagen", "Debe Insertar Imagen");
                    return PartialView("_Nuevo", subCategoriaModel);
                }

            }
            return PartialView("_Nuevo", subCategoriaModel);
        }

        [HttpPost]
        public ActionResult Modificar(SubCategoriaModel subCategoriaModel)
        {
            if (ModelState.IsValid)
            {
                if (subCategoriaModel.FotoImagen == null && string.IsNullOrEmpty(subCategoriaModel.ImagenUrl))
                {
                    ModelState.AddModelError("FotoImagen", "Debe Insertar Imagen");
                    return PartialView("_Nuevo", subCategoriaModel);
                }

                var mantencionSubCategoria = new MantencionSubCategoriaViewModel();
                mantencionSubCategoria.Modificar(subCategoriaModel);
                TempData["msg"] = "Sub-Categoría modificado correctamente.";
                return Json(new { success = true });
            }
            return PartialView("_Nuevo", subCategoriaModel);
        }
    }
}