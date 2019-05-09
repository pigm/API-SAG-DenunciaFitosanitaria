using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    [CustomAuthorize(1)]
    public class SolicitudDenunciaController : Controller
    {
        public ActionResult Index()
        {
            var solicitudDenuncia = new SolicitudDenunciaViewModel();
            solicitudDenuncia.ListarDenunciasPendientes();
            return View(solicitudDenuncia);
        }

        public ActionResult VerDenuncia(int idDenuncia)
        {
            var solicitudDenuncia = new SolicitudDenunciaViewModel();
            solicitudDenuncia.ObtenerTipoDenuncia(idDenuncia);
            var imagenFisica = HostingEnvironment.MapPath(string.Format("~/DenunciaFitosanitariaFiles/Images/{0}", solicitudDenuncia.Denuncia.ImagenUrl));
            solicitudDenuncia.Denuncia.MensajeVoz = Url.Content(string.Format("~/DenunciaFitosanitariaFiles/Audios/{0}", solicitudDenuncia.Denuncia.MensajeVoz));
            solicitudDenuncia.Denuncia.ImagenUrl = Url.Content(string.Format("~/DenunciaFitosanitariaFiles/Images/{0}", solicitudDenuncia.Denuncia.ImagenUrl));

            FileInfo fileImagenUrl = new FileInfo(imagenFisica);
            if (!fileImagenUrl.Exists)
                solicitudDenuncia.Denuncia.ImagenUrl = "/assets/apps/img/NoImage.png";

            solicitudDenuncia.Denuncia.ListaSubCategoriaDenuncia = Funciones.Funciones.ObtenerSubcategoriaxCategoria(solicitudDenuncia.Denuncia.IdCategoria);
            return PartialView("_VerDenuncia", solicitudDenuncia.Denuncia);
        }

        public ActionResult Busqueda(FormCollection form)
        {
            SolicitudDenunciaViewModel model = new SolicitudDenunciaViewModel();
            model.Buscar(form);
            return PartialView("_Busqueda", model);
        }

        public void Descarga(FormCollection form)
        {
            DescargaDenunciaModel generaExcel = new DescargaDenunciaModel();
            this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            this.Response.AddHeader("content-disposition", string.Format("attachment;  filename={0}", "DenunciasBandejaEntrada.xlsx"));
            this.Response.BinaryWrite(generaExcel.DescargaBandejaEntrada(form));
        }

        public ActionResult ModificarDenuncia(FormCollection denunciaModel)
        {
            if (ModelState.IsValid)
            {
                var solicitudDenuncia = new SolicitudDenunciaViewModel();
                solicitudDenuncia.ModificarDenuncia(denunciaModel);
                TempData["msg"] = "Tipo de Denuncia modificada correctamente.";
                return Json(new { success = true });
            }
            return PartialView("_Nuevo", denunciaModel);
        }
    }
}