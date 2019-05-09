using Denuncia.Datos.Repositorio;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denuncia.Negocio
{
    public class SubCategoriaServicio
    {
        public List<SubCategoria> ListaSubCategoria()
        {
            var repositorio = new SubCategoriaRepositorio();
            return repositorio.ListaSubCategoria();
        }

        public List<SubCategoria> ListaSubCategoriaMantenedor()
        {
            var repositorio = new SubCategoriaRepositorio();
            return repositorio.ListaSubCategoriaMantenedor();
        }

        public List<SubCategoria> ListaSubCategoriaPorRol(string roleName)
        {
            var repositorio = new SubCategoriaRepositorio();
            return repositorio.ListaSubCategoriaPorRol(roleName);
        }

        public SubCategoria Obtener(int idSubCategoria)
        {
            var repositorio = new SubCategoriaRepositorio();
            return repositorio.ObtenerSubCategoria(idSubCategoria);
        }

        public SubCategoria Agregar(SubCategoria subCategoriaEntidad)
        {
            var repositorio = new SubCategoriaRepositorio();
            repositorio.Agregar(subCategoriaEntidad);
            repositorio.RealizarCambios();
            return subCategoriaEntidad;
        }
        public void Modificar(SubCategoria subCategoriaEntidad)
        {
            var repositorio = new SubCategoriaRepositorio();
            repositorio.Modificar(subCategoriaEntidad);
            repositorio.RealizarCambios();
        }
    }
}
