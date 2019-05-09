using Denuncia.Datos.Core;
using System.Linq;
using Denuncia.Entidad;
using System.Collections.Generic;

namespace Denuncia.Datos.Repositorio
{
    public class RolAcessoWebSiteMapRepositorio : BaseRepositorio<RolesAccesosWebSiteMap>
    {
        
        public List<RolesAccesosWebSiteMap> ObtenerxRol(string rolName)
        {
            return this._Context.RolesAccesosWebSiteMap.Where(rol => rol.RoleName == rolName).ToList();
        }
    }
}
