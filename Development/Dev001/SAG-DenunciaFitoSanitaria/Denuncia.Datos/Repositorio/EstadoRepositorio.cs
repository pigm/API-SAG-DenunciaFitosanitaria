using Denuncia.Datos.Core;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denuncia.Datos.Repositorio
{
    public class EstadoRepositorio : BaseRepositorio<EstadoDenuncia>
    {
        public List<EstadoDenuncia> ListaEstado()
        {
            return this._Context.EstadoDenuncia.ToList();
        }

        public EstadoDenuncia ObtenerEstado(int idEstado)
        {
            return this._Context.EstadoDenuncia.SingleOrDefault(EstadoD => EstadoD.IdEstadoDenuncia == idEstado);
        }
    }
}
