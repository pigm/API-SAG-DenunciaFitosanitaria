using Denuncia.Datos.Repositorio;
using Denuncia.Entidad;
using System.Collections.Generic;

namespace Denuncia.Negocio
{
    public class CategoriaServicio
    {
        public List<Categoria> ListaCategorias()
        {
            var repositorio = new CategoriaRepositorio();
            return repositorio.ListaCategorias();
        }

        public List<Categoria> ListaCategoriasMantenedor()
        {
            var repositorio = new CategoriaRepositorio();
            return repositorio.ListaCategoriasMantedor();
        }

        public List<Categoria> ListaCategoriasPorRol(string userName)
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            return repositorio.ListaCategoriasUser(userName);
        }


        public Categoria ObtenerCategoria(int idCategoria)
        {
            var repositorio = new CategoriaRepositorio();
            return repositorio.ObtenerCategoria(idCategoria);
        }

        public void Agregar(Categoria categoriaEntidad)
        {
            var repositorio = new CategoriaRepositorio();
            repositorio.Agregar(categoriaEntidad);
            repositorio.RealizarCambios();
        }
        
        public void Modificar(Categoria categoriaEntidad)
        {
            var repositorio = new CategoriaRepositorio();
            repositorio.Modificar(categoriaEntidad);
            repositorio.RealizarCambios();
        }
    }
}
