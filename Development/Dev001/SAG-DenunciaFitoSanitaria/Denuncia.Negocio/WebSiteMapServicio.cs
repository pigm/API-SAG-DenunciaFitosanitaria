using Denuncia.Datos.Repositorio;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denuncia.Negocio
{
    public class WebSiteMapServicio
    {
        public List<WebSiteMap> ListaMenu()
        {
            using (var repositorio = new WebSiteMapRepositorio())
            {
                return repositorio.ObtenerMenu();
            }
        }

        public void EliminarAccesoxRol(string rolName, int[] accesoMenus)
        {
            using (var repositorio = new RolAcessoWebSiteMapRepositorio())
            {
                foreach (var menu in accesoMenus)
                {
                    repositorio.Eliminar(new RolesAccesosWebSiteMap { RoleName = rolName, WebSiteMapId = menu });
                }
                repositorio.RealizarCambios();
            }
        }

        public void GuardarAccesoxRol(string rolName, string[] accesoMenus)
        {
            using (var repositorio = new RolAcessoWebSiteMapRepositorio())
            {
                foreach (var menu in accesoMenus)
                {
                    repositorio.Agregar(new RolesAccesosWebSiteMap { RoleName = rolName, WebSiteMapId = int.Parse(menu) });
                }
                repositorio.RealizarCambios();
            }
        }

        public List<WebSiteMap> ObtenerAccesosxRol(string rolName)
        {
            using (var repositorio = new RolAcessoWebSiteMapRepositorio())
            {
                return repositorio.ObtenerxRol(rolName).Select(rol => rol.WebSiteMap).ToList();
            }
        }

        public int[] ObtenerIdAccesosxRol(string rolName)
        {
            using (var repositorio = new RolAcessoWebSiteMapRepositorio())
            {
                return repositorio.ObtenerxRol(rolName).Select(rol => rol.WebSiteMapId).ToArray();
            }
        }

        public string[] ObtenerRolesAcceso(int accesoId)
        {
            using (var repositorio = new WebSiteMapRepositorio())
            {
                return repositorio.ObtenerMenuAcceso(accesoId).RolesAccesosWebSiteMap.Select(rol => rol.RoleName).Distinct().ToArray();
            }
        }
    }
}
