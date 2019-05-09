using Denuncia.Datos.Repositorio;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;

namespace Denuncia.Negocio
{
    public class TipoDenunciaServicio
    {
        public List<TipoDenuncia> ListaTipoDenuncia()
        {

            var tipoDenunciaRepositorio = new TipoDenunciaRepositorio();
            return tipoDenunciaRepositorio.ListaTipoDenuncia();
        }

        public List<TipoDenuncia> ListaTipoDenuncia(string userName)
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            return repositorio.ListaTiposUser(userName);
        }


        public TipoDenuncia ObtenerTipoDenuncia(int idTipoDenuncia)
        {
            var repositorio = new TipoDenunciaRepositorio();
            return repositorio.ObtenerTipoDenuncia(idTipoDenuncia);
        }

        public void Agregar(TipoDenuncia tipoDenunciaEntidad)
        {
            using (var repositorio = new TipoDenunciaRepositorio())
            {
                repositorio.Agregar(tipoDenunciaEntidad);
                repositorio.RealizarCambios();
            }
        }

        public void Modificar(TipoDenuncia tipoDenunciaEntidad)
        {
            using (var repositorio = new TipoDenunciaRepositorio())
            {
                repositorio.Modificar(tipoDenunciaEntidad);
                repositorio.RealizarCambios();
            }
        }

        public List<TipoDenuncia> ListaDenuncia(int? idTipoDenuncia)
        {
            var repositorio = new TipoDenunciaRepositorio();
            return repositorio.ListaTipoDenuncia();
        }


    }
}
