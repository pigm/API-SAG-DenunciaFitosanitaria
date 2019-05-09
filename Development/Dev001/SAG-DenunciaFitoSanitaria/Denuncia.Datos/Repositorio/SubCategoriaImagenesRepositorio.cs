using Denuncia.Datos.Core;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;


namespace Denuncia.Datos.Repositorio
{
    public class SubCategoriaImagenesRepositorio : BaseRepositorio<Entidad.SubCategoria_Imagenes>
    {
        public SubCategoria_Imagenes ObtenerSubCategoriaImagenes(int idSubCategoria)
        {
            return this._Context.SubCategoria_Imagenes.SingleOrDefault(tc => tc.IdSubCategoria == idSubCategoria);
        }
    }
}
