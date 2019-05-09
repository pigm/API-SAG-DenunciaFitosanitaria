using Denuncia.Datos.Core;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denuncia.Datos.Repositorio
{
    public class RoleRepositorio : BaseRepositorio<aspnet_Roles>
    {
        public aspnet_Roles ObtenerRol(string roleName)
        {
            return this._Context.aspnet_Roles.SingleOrDefault(rol => rol.LoweredRoleName == roleName.ToLower());
        }
    }
}
