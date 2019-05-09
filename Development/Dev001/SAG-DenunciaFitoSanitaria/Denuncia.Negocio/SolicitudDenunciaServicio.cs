using Denuncia.Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Denuncia.Negocio
{
    public class SolicitudDenunciaServicio
    {
        public List<Entidad.Denuncia> ListaDenuncia()
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            return repositorio.ListaDenuncias(string.Empty);
        }

        public List<Entidad.Denuncia> ListaDenunciaPorUsuario(string userName)
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            return repositorio.ListaDenuncias(userName);
        }

        public List<Entidad.Denuncia> ListaDenunciaInformeGeneralPorUsuario(string userName)
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            return repositorio.ListaDenuncias(userName).Where(ent => ent.IdEstadoDenuncia != (int)Entidad.Enums.EnumEstadoDenuncia.Pendiente).ToList();
        }

        public List<Entidad.Denuncia> ListaDenunciaPendientesPorUsuario(string userName)
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            var estadoDenuncia = ((int)Entidad.Enums.EnumEstadoDenuncia.Pendiente).ToString();
            return repositorio.Buscar(estadoDenuncia, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, userName).ToList();
        }

        public List<Entidad.Denuncia> Buscar(string estadoDenuncia, string IdtipoDenuncia,
            string FechaSolicitudDesde, string FechaSolicitudHasta,
            string IdCategoria, string IdSubCategoria,
            string Region, string Comuna,
            string userName)
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            return repositorio.Buscar(estadoDenuncia, IdtipoDenuncia, FechaSolicitudDesde, FechaSolicitudHasta, IdCategoria, IdSubCategoria, Region, Comuna, userName).ToList();
        }

        public Entidad.Denuncia ObtenerDenuncia(int idDenuncia)
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            return repositorio.ObtenerDenuncia(idDenuncia);
        }

        public void ModificarDenuncia(Entidad.Denuncia entidadDenuncia)
        {
            var repositorio = new SolicitudDenunciaRepositorio();
            repositorio.Modificar(entidadDenuncia);
            repositorio.RealizarCambios();
        }
    }
}
