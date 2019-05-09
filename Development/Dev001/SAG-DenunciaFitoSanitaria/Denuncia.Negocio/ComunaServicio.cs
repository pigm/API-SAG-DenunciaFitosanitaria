using Denuncia.Datos.Repositorio;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denuncia.Negocio
{
    public class ComunaServicio
    {
        public string[] ListaComuna()
        {
            using (var repositorio = new SolicitudDenunciaRepositorio())
            {
                return repositorio.ListaComunas();
            }
        }

        public string[] ListaComunaUser(string userName)
        {
            using (var repositorio = new SolicitudDenunciaRepositorio())
            {
                return repositorio.ListaComunaUser(userName);
            }
        }
    }
}
