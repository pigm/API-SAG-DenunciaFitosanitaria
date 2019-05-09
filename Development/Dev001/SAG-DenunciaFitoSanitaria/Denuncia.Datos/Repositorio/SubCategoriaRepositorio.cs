using Denuncia.Datos.Core;
using Denuncia.Entidad;
using System.Collections.Generic;
using System.Linq;

namespace Denuncia.Datos.Repositorio
{
    public class SubCategoriaRepositorio : BaseRepositorio<SubCategoria>
    {
        //19-10-2018 CT:Se cambian los metodos del repositorio para que solo obtenga las subcategorias activas

        public List<SubCategoria> ListaSubCategoria()
        {
            return this._Context.SubCategoria.Where(sub => sub.Estado == true).ToList();
        }
        public List<SubCategoria> ListaSubCategoriaPorRol(string roleName)
        {
            return this._Context.SubCategoria.Where(sub => sub.Estado == true && sub.aspnet_Roles.Any(rol => rol.LoweredRoleName == roleName.ToLower())).ToList();
        }

        public List<SubCategoria> ListaSubCategoriaMantenedor()
        {
            return this._Context.SubCategoria.Include("SubCategoria_Imagenes").ToList();
        }

        public SubCategoria ObtenerSubCategoria(int idSubCategoria)
        {
            return this._Context.SubCategoria.SingleOrDefault(tc => tc.IdSubCategoria == idSubCategoria);
        }
    }
}
