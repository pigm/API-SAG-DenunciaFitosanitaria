using Denuncia.Datos.Core;
using Denuncia.Entidad;
using System.Collections.Generic;
using System.Linq;

namespace Denuncia.Datos.Repositorio
{
    public class CategoriaRepositorio : BaseRepositorio<Categoria>
    {
        //19-10-2018 CT:Se cambian los metodos del repositorio para que solo obtenga las categorias activas

        public List<Categoria> ListaCategorias()
        {
            return this._Context.Categoria.Where(cat => cat.Estado == true).ToList();
        }

        public List<Categoria> ListaCategoriasMantedor()
        {
            return this._Context.Categoria.ToList();
        }

        public List<Categoria> ListaCategoriasPorRol(string roleName)
        {
            return this._Context.Categoria.Where(cat => cat.SubCategoria.Any(sub => sub.aspnet_Roles.Any(rol => rol.LoweredRoleName == roleName.ToLower()))).ToList();
        }

        public Categoria ObtenerCategoria(int idCategoria)
        {
            return this._Context.Categoria.SingleOrDefault(tc => tc.IdCategoria == idCategoria);
        }
    }
}
