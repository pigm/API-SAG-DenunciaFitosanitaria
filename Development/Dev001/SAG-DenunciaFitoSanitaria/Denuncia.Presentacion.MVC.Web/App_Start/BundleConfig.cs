using System.Web;
using System.Web.Optimization;

namespace Denuncia.Presentacion.MVC.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/DenunciaFitoSanitaria/script").Include(
                         "~/assets/apps/scripts/appDenunciaFitoSanitaria.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                                  "~/Content/bootstrap.css",
                                  "~/Content/bootstrap-datepicker.min.css",
                                  "~/Content/site.css"));
            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            
            bundles.Add(new ScriptBundle("~/MantencionTipoDenuncia/script").Include(
                    "~/assets/apps/scripts/mantencionTipoDenuncia.js",
                    "~/assets/global/plugins/filedownloader/filedownloader.js"));

            bundles.Add(new ScriptBundle("~/MantencionUsuario/script").Include(
                    "~/assets/apps/scripts/mantencionUsuario.js"));

            bundles.Add(new ScriptBundle("~/MantencionRol/script").Include(
                    "~/assets/apps/scripts/mantencionRol.js"));

            bundles.Add(new ScriptBundle("~/MantencionCategoria/script").Include(
                    "~/assets/apps/scripts/mantencionCategoria.js",
                    "~/assets/global/plugins/filedownloader/filedownloader.js"));

            bundles.Add(new ScriptBundle("~/MantencionSubCategoria/script").Include(
                    "~/assets/apps/scripts/mantencionSubCategoria.js",
                    "~/assets/global/plugins/filedownloader/filedownloader.js"));

            bundles.Add(new ScriptBundle("~/SolicitudDenuncia/script").Include(
                    "~/assets/apps/scripts/solicitudDenuncia.js",
                    "~/assets/global/plugins/moment.js"));

            bundles.Add(new ScriptBundle("~/InformeGeneral/script").Include(
                   "~/assets/apps/scripts/InformeGeneral.js"));

            bundles.Add(new ScriptBundle("~/InformeEspacial/script").Include(
                 "~/assets/apps/scripts/InformeEspacial.js"));
        }
    }
}
