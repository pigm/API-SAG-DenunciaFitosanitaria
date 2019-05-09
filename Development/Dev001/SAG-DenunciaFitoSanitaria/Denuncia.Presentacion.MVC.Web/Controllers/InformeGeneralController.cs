using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using System;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    [CustomAuthorize(10)]
    public class InformeGeneralController : Controller
    {
        public ActionResult Index()
        {
            SolicitudDenunciaModel model = new SolicitudDenunciaModel();
            model.LlenaListas();
            return View(model);
        }

        [HttpPost]
        public ActionResult Busqueda(FormCollection form)
        {           
            SolicitudDenunciaModel model = new SolicitudDenunciaModel();
            model.Buscar(form);
            return PartialView("_Busqueda", model);
        }

        public void Descarga(FormCollection form)
        {
            DescargaDenunciaModel generaExcel = new DescargaDenunciaModel();
            this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            this.Response.AddHeader("content-disposition", string.Format("attachment;  filename={0}", "DenunciasReporteGeneral.xlsx"));
            this.Response.BinaryWrite(generaExcel.DescargaReporteGeneral(form));
        }

        public ActionResult VerDenuncia(int idDenuncia)
        {
            var solicitudDenuncia = new SolicitudDenunciaViewModel();
            solicitudDenuncia.ObtenerTipoDenuncia(idDenuncia);
            solicitudDenuncia.Denuncia.MensajeVoz = Url.Content(string.Format("~/DenunciaFitosanitariaFiles/Audios/{0}", solicitudDenuncia.Denuncia.MensajeVoz));
            solicitudDenuncia.Denuncia.ImagenUrl = Url.Content(string.Format("~/DenunciaFitosanitariaFiles/Images/{0}", solicitudDenuncia.Denuncia.ImagenUrl));
            return PartialView("_VerDenuncia", solicitudDenuncia.Denuncia);
        }

    }
}