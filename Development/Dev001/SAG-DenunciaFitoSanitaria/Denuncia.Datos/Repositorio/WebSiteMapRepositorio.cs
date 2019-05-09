using Denuncia.Datos.Core;
using Denuncia.Entidad;
using System.Collections.Generic;
using System.Linq;

namespace Denuncia.Datos.Repositorio
{
    public class WebSiteMapRepositorio : BaseRepositorio<WebSiteMap>
    {
        public List<WebSiteMap> ObtenerMenu()
        {
            return this._Context.WebSiteMap.ToList();
        }

        public WebSiteMap ObtenerMenuAcceso(int accesoId)
        {
            return this._Context.WebSiteMap.SingleOrDefault(web => web.ID == accesoId);
        }
    }
}
