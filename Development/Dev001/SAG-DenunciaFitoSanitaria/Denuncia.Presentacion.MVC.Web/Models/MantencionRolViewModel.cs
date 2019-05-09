using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class MantencionRolViewModel
    {
        public RolModel Rol { get; set; }
        public List<RolModel> ListaRoles { get; set; }

        public void ObtenerRoles()
        {
            ListaRoles = new List<RolModel>();
            var listaRoles = Roles.GetAllRoles();
            foreach (string rol in listaRoles)
            {
                ListaRoles.Add(new RolModel
                {
                    Nombre = rol
                });
            }
        }

        public void ObtenerRol(string rolName)
        {
            Rol = new RolModel();
            var rol = Roles.GetAllRoles();
            Rol.Nombre = rol.SingleOrDefault(s => s.ToString() == rolName);
            var rolAccesosServicios = new WebSiteMapServicio();
            int [] menuAccesos = rolAccesosServicios.ObtenerIdAccesosxRol(rolName);
            Rol.Acceso = string.Join(",", menuAccesos);

            Rol.ObtenerSubCategorias();
            var userSubCategoriaServicio = new RoleSubCategoriaServicio();
            var listaSubCategorias = userSubCategoriaServicio.ListaSubCategoria(Rol.Nombre);
            Rol.IdSubCategoria = listaSubCategorias.Select(cat => cat.IdSubCategoria).ToArray();
        }

        public bool Agregar()
        {
            if (!Roles.RoleExists(Rol.Nombre))
            {
                Roles.CreateRole(Rol.Nombre);
                var rolAccesosServicios = new WebSiteMapServicio();
                rolAccesosServicios.GuardarAccesoxRol(Rol.Nombre, Rol.Acceso.Split(','));
                var userSubCategoriaServicio = new RoleSubCategoriaServicio();
                userSubCategoriaServicio.Asociar(Rol.Nombre, Rol.IdSubCategoria);
                return true;
            }
            return false;
        }

        public bool Modificar()
        {
            if (Roles.RoleExists(Rol.Nombre))
            {
                var rolAccesosServicios = new WebSiteMapServicio();
                int[] menuAccesos = rolAccesosServicios.ObtenerIdAccesosxRol(Rol.Nombre);
                rolAccesosServicios.EliminarAccesoxRol(Rol.Nombre, menuAccesos);
                rolAccesosServicios.GuardarAccesoxRol(Rol.Nombre, Rol.Acceso.Split(','));
                var userSubCategoriaServicio = new RoleSubCategoriaServicio();
                userSubCategoriaServicio.Asociar(Rol.Nombre, Rol.IdSubCategoria);
                return true;
            }
            return false;
        }

        public bool Eliminar(string roleName)
        {
            string[] usuarios = Roles.GetUsersInRole(roleName);           
            if (usuarios.Length == 0)
            {
                var rolAccesosServicios = new WebSiteMapServicio();
                int[] menuAccesos = rolAccesosServicios.ObtenerIdAccesosxRol(roleName);
                rolAccesosServicios.EliminarAccesoxRol(roleName, menuAccesos);
                var userSubCategoriaServicio = new RoleSubCategoriaServicio();
                userSubCategoriaServicio.Desasociar(roleName);
                Roles.DeleteRole(roleName);
                return true;
            }
            return false;
        }
    }
}