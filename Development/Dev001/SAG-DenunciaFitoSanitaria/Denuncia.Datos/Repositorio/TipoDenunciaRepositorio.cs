using Denuncia.Datos.Core;
using Denuncia.Datos.Core.Specification;
using Denuncia.Entidad;
using System.Collections.Generic;
using System.Linq;

namespace Denuncia.Datos.Repositorio
{
    public class TipoDenunciaRepositorio : BaseRepositorio<TipoDenuncia>
    {
        public List<TipoDenuncia> ListaTipoDenuncia()
        {
            return this._Context.TipoDenuncia.ToList();
        }


        public TipoDenuncia ObtenerTipoDenuncia(int idcateTipoDenuncia)
        {
            return this._Context.TipoDenuncia.SingleOrDefault(td => td.IdTipoDenuncia == idcateTipoDenuncia);
        }

        public IEnumerable<TipoDenuncia> ListaTipoDenuncia(int? idDenuncia)
        {
            Specification<TipoDenuncia> spec = new TrueSpecification<TipoDenuncia>();

            if (idDenuncia.HasValue)
                spec &= new DirectSpecification<TipoDenuncia>(denu => denu.IdTipoDenuncia == idDenuncia.Value);

            //if (fechaSolicitudDesde != null)
            //    spec &= new DirectSpecification<Solicitud>(sol => sol.FechaIngreso >= fechaSolicitudDesde);

            //if (fechaSolicitudHasta != null)
            //    spec &= new DirectSpecification<Solicitud>(sol => sol.FechaIngreso <= fechaSolicitudHasta);

            //if (IdSolicitudRetiro.HasValue)
            //    spec &= new DirectSpecification<Solicitud>(sol => sol.IdSolicitudRetiro == IdSolicitudRetiro.Value);

            //if (idTipoRecall.HasValue)
            //    spec &= new DirectSpecification<Solicitud>(sol => sol.IdTipoRecall == idTipoRecall.Value);

            //if (idMotivoBloqueo.HasValue)
            //    spec &= new DirectSpecification<Solicitud>(sol => sol.IdMotivoBloqueo == idMotivoBloqueo.Value);

            return base.ObtenerPorParametros(spec);

        }
    }
}
