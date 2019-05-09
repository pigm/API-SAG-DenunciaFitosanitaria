using Denuncia.Presentacion.MVC.Web.Autorizacion;
using Denuncia.Presentacion.MVC.Web.Models;
using System.Web.Mvc;
using System.Linq;

namespace Denuncia.Presentacion.MVC.Web.Controllers
{
    [CustomAuthorize(9)]
    public class InformeEspacialController : Controller
    {
        public ActionResult Index()
        {
            SolicitudDenunciaModel model = new SolicitudDenunciaModel();
            model.LlenaListas();
            return View(model);
        }
        
        public ActionResult Busquedajson(FormCollection form)
        {
            SolicitudDenunciaModel model = new SolicitudDenunciaModel();
            model.BuscarEspacial(form);

            var result = from d in model.ListaDenunciasInforme
                         select new[] { d.IdDenuncia.ToString(), d.IdEstadoDenuncia.ToString(), d.latitud.ToString(), d.longitud.ToString(), d.EstadoDenuncia.ToString() };
            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }

    }
}