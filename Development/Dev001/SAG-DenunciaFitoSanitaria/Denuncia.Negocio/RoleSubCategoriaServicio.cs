using Denuncia.Datos.Repositorio;
using Denuncia.Entidad;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Denuncia.Negocio
{
    public class RoleSubCategoriaServicio
    {
        public List<SubCategoria> ListaSubCategoria(string roleName)
        {
            using (var repositorio = new RoleRepositorio())
            {
                var role = repositorio.ObtenerRol(roleName);
                if (role != null)
                {
                    return role.SubCategoria.ToList();
                }
                return new List<SubCategoria>();
            }
        }

        public void Asociar(string roleName, int[] subCategorias)
        {
            using (var repositorio = new RoleRepositorio())
            {
                using (var repositorioSubCategorioa = new SubCategoriaRepositorio())
                {
                    var usuario = repositorio.ObtenerRol(roleName);
                    if (usuario != null)
                    {
                        usuario.SubCategoria.Clear();
                        foreach (var idSubCategoria in subCategorias)
                        {
                            var subCategoria = repositorioSubCategorioa.ObtenerSubCategoria(idSubCategoria);
                            usuario.SubCategoria.Add(subCategoria);
                        }
                        repositorio.Modificar(usuario);
                        repositorio.RealizarCambios();
                    }
                }
            }
        }

        public void Desasociar(string roleName)
        {
            using (var repositorio = new RoleRepositorio())
            {
                using (var repositorioSubCategorioa = new SubCategoriaRepositorio())
                {
                    var usuario = repositorio.ObtenerRol(roleName);
                    if (usuario != null)
                    {
                        usuario.SubCategoria.Clear();
                        repositorio.Modificar(usuario);
                        repositorio.RealizarCambios();
                    }
                }
            }
        }



    }
}
