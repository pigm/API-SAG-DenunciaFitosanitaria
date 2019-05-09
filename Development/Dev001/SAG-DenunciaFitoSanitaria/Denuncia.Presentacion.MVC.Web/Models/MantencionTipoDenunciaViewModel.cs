using AutoMapper;
using Denuncia.Entidad;
using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class MantencionTipoDenunciaViewModel
    {


        public MantencionTipoDenunciaViewModel()
        {
            listTipo = Funciones.Funciones.ObtenerTipos(Autorizacion.IdentityUser.UserName);
            ListaCategoria = Funciones.Funciones.ObtenerCategoria(Autorizacion.IdentityUser.UserName);
            ListaRegion = Funciones.Funciones.ObtenerRegion(Autorizacion.IdentityUser.UserName);
            ListaSubCategoria = Funciones.Funciones.ObtenerSubcategoria();
            ListaComuna = Funciones.Funciones.ObtenerComuna(Autorizacion.IdentityUser.UserName);
            ListaEstado = Funciones.Funciones.ObtenerEstado();
        }

        public string fechaDesde { get; set; }
        public string fechaHasta { get; set; }
        public int IdTipoDenuncia { get; set; }
        public int IdCategoria { get; set; }
        public int IdRegion { get; set; }
        public int IdSubCategoria { get; set; }
        public int IdComuna { get; set; }

        public int IdEstado { get; set; }

        public TipoDenunciaModel TipoDenunciaModel { get; set; }

        public List<SelectListItem> listTipo { get; set; }

        public List<SelectListItem> ListaCategoria { get; set; }

        public List<SelectListItem> ListaRegion { get; set; }

        public List<SelectListItem> ListaSubCategoria { get; set; }

        public List<SelectListItem> ListaComuna { get; set; }

        public List<SelectListItem> ListaEstado { get; set; }

        public List<TipoDenunciaModel> ListaTipoDenuncia { get; set; }

        public List<SolicitudDenunciaModel> ListaDenunciasInforme { get; set; }

        public void ListarDenuncia()
        {
            var denunciaServicio = new SolicitudDenunciaServicio();
            var listadoDenuncia = denunciaServicio.ListaDenuncia();
            ListaDenunciasInforme = Mapper.Map<List<SolicitudDenunciaModel>>(listadoDenuncia);
        }

        public void ListarTipoDenuncia()
        {
            ListaTipoDenuncia = new List<TipoDenunciaModel>();
            var tipoDenunciaServicio = new TipoDenunciaServicio();
            var listadoTipoDenuncia = tipoDenunciaServicio.ListaTipoDenuncia();
            ListaTipoDenuncia = Mapper.Map<List<TipoDenunciaModel>>(listadoTipoDenuncia);
        }

        public void ObtenerTipoDenuncia(int idTipoDenuncia)
        {
            TipoDenunciaModel = new TipoDenunciaModel();
            var tipoDenunciaServicio = new TipoDenunciaServicio();
            var tipoDenunciaEntidad = tipoDenunciaServicio.ObtenerTipoDenuncia(idTipoDenuncia);
            TipoDenunciaModel = Mapper.Map<TipoDenunciaModel>(tipoDenunciaEntidad);
        }

        public void Agregar(TipoDenunciaModel tipoDenunciaModel)
        {
            var tipoDenunciaServicio = new TipoDenunciaServicio();
            var tipoDenunciaEntidad = new TipoDenuncia();
            tipoDenunciaEntidad.Nombre = tipoDenunciaModel.Nombre;
            tipoDenunciaEntidad.Estado = tipoDenunciaModel.Estado;
            tipoDenunciaEntidad.Incognito = tipoDenunciaModel.Incognito;
            tipoDenunciaServicio.Agregar(tipoDenunciaEntidad);
        }

        public void Modificar(TipoDenunciaModel tipoDenunciaModel)
        {
            var tipoDenunciaServicio = new TipoDenunciaServicio();
            var tipoDenunciaEntidad = tipoDenunciaServicio.ObtenerTipoDenuncia(tipoDenunciaModel.IdTipoDenuncia);
            tipoDenunciaEntidad.IdTipoDenuncia = tipoDenunciaModel.IdTipoDenuncia;
            tipoDenunciaEntidad.Nombre = tipoDenunciaModel.Nombre;
            tipoDenunciaEntidad.Estado = tipoDenunciaModel.Estado;
            tipoDenunciaEntidad.Incognito = tipoDenunciaModel.Incognito;
            tipoDenunciaServicio.Modificar(tipoDenunciaEntidad);
        }

    }
}