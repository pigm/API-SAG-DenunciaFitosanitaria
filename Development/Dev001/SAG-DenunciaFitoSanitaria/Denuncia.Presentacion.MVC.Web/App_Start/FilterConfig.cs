using System.Web;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
