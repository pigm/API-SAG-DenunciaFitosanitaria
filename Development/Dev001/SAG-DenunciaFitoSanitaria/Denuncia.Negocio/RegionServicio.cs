using Denuncia.Datos.Repositorio;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denuncia.Negocio
{
    public class RegionServicio
    {
        public string[] ListaRegiones()
        {
            using (var repositorio = new SolicitudDenunciaRepositorio())
            {
                return repositorio.ListaRegiones();
            }
        }

        public string[] ListaRegionesUser(string userName)
        {
            using (var repositorio = new SolicitudDenunciaRepositorio())
            {
                return repositorio.ListaRegionesUser(userName);
            }
        }

    }
}
