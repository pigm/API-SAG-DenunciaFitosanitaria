using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    [CustomAuthorize(4)]
    public class MantencionCategoriaController : Controller
    {
        public ActionResult Index()
        {
            var mantencionCategoriaViewModel = new MantencionCategoriaViewModel();
            mantencionCategoriaViewModel.ListarCategoriasMantenedor();
            return View(mantencionCategoriaViewModel.ListaCategoria);
        }

        public ActionResult Nuevo()
        {
            CategoriaModel categoriaModel = new CategoriaModel();
            return PartialView("_Nuevo", categoriaModel);
        }

        public ActionResult Editar(int idCategoria, int IdTipoDenuncia)
        {
            var mantencionCategoriaViewModel = new MantencionCategoriaViewModel();
            mantencionCategoriaViewModel.ObtenerCategoria(idCategoria);
            var solicitudDenuncia = new SolicitudDenunciaViewModel();
            mantencionCategoriaViewModel.CategoriaModel.EsNuevo = false;
            return PartialView("_Nuevo", mantencionCategoriaViewModel.CategoriaModel);
        }

        [HttpPost]
        public ActionResult Crear(CategoriaModel categoriaModel)
        {
            if (ModelState.IsValid)
            {
                if (categoriaModel.FotoImagen != null)
                {
                    var mantencionCategoriaViewModel = new MantencionCategoriaViewModel();
                    mantencionCategoriaViewModel.Agregar(categoriaModel);
                    TempData["msg"] = "Categoría creada correctamente.";
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("FotoImagen", "Debe Insertar Imagen");
                    return PartialView("_Nuevo", categoriaModel);
                }
            }
            return PartialView("_Nuevo", categoriaModel);
        }

        [HttpPost]
        public ActionResult Modificar(CategoriaModel categoriaModel)
        {
            if (ModelState.IsValid)
            {
                var mantencionCategoriaViewModel = new MantencionCategoriaViewModel();
                mantencionCategoriaViewModel.Modificar(categoriaModel);
                TempData["msg"] = "Categoría modificada correctamente.";
                return Json(new { success = true });
            }
            return PartialView("_Nuevo", categoriaModel);
        }
    }
}