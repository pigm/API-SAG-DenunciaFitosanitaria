using Denuncia.Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denuncia.Negocio
{
    public class SubCategoriaImagenesServicio
    {
        public Entidad.SubCategoria_Imagenes Obtener(int IdSubcategoria)
        {
            var repositorio = new SubCategoriaImagenesRepositorio();
            return repositorio.ObtenerSubCategoriaImagenes(IdSubcategoria);
        }

        public void Modificar(Entidad.SubCategoria_Imagenes subCategoriaImagenesEntidad)
        {
            var repositorio = new SubCategoriaImagenesRepositorio();
            repositorio.Modificar(subCategoriaImagenesEntidad);
            repositorio.RealizarCambios();
        }
        public void Agregar(Entidad.SubCategoria_Imagenes subCategoriaImagenesEntidad)
        {
            var repositorio = new SubCategoriaImagenesRepositorio();
            repositorio.Agregar(subCategoriaImagenesEntidad);
            repositorio.RealizarCambios();
        }
    }
}
