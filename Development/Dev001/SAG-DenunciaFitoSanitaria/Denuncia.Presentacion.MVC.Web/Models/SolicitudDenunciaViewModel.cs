using AutoMapper;
using Denuncia.Negocio;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class SolicitudDenunciaViewModel
    {

        public SolicitudDenunciaViewModel()
        {
            listTipo = Funciones.Funciones.ObtenerTipos(Autorizacion.IdentityUser.UserName);
            ListaCategoria = Funciones.Funciones.ObtenerCategoria(Autorizacion.IdentityUser.UserName);
            ListaRegion = Funciones.Funciones.ObtenerRegion(Autorizacion.IdentityUser.UserName);
            ListaSubCategoria = Funciones.Funciones.ObtenerSubcategoria();
            ListaComuna = Funciones.Funciones.ObtenerComuna(Autorizacion.IdentityUser.UserName);
            ListaEstado = Funciones.Funciones.ObtenerEstado();
            BusquedaDenuncia = new BusquedaDenunciaModel();
            ListaDenuncias = new List<SolicitudDenunciaModel>();
        }

        public string DescripcionCortada { get; set; }
        public string Referencia { get; set; }

        public BusquedaDenunciaModel BusquedaDenuncia { get; set; }
        public SolicitudDenunciaModel Denuncia { get; set; }
        public List<SolicitudDenunciaModel> ListaDenuncias { get; set; }

        public List<SelectListItem> ListaTipo { get; set; }
        public List<SelectListItem> ListaCategoria { get; set; }
        public List<SelectListItem> ListaRegion { get; set; }
        public List<SelectListItem> ListaSubCategoria { get; set; }
        public List<SelectListItem> ListaComuna { get; set; }

        public List<SelectListItem> ListaEstado { get; set; }

        public int IdTipoDenuncia { get; set; }
        public int IdCategoria { get; set; }
        public int IdRegion { get; set; }
        public int IdSubCategoria { get; set; }
        public int IdComuna { get; set; }
        public int IdEstado { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string EstadoDenuncia { get; set; }

        public DateTime? Datefrom { get; set; }
        public DateTime? DateTo { get; set; }

        public List<SelectListItem> listTipo { get; set; }
        public bool DenunciaRapida { get; set; }

        public List<SolicitudDenunciaModel> ListaDenunciasInforme { get; set; }

        public void ListarDenuncia()
        {
            var denunciaServicio = new SolicitudDenunciaServicio();
            var listadoDenuncia = denunciaServicio.ListaDenunciaPorUsuario(Autorizacion.IdentityUser.UserName);
            ListaDenuncias = Mapper.Map<List<SolicitudDenunciaModel>>(listadoDenuncia);
        }

        public void ListarDenunciasPendientes()
        {
            var denunciaServicio = new SolicitudDenunciaServicio();
            var listadoDenuncia = denunciaServicio.ListaDenunciaPendientesPorUsuario(Autorizacion.IdentityUser.UserName);
            ListaDenunciasInforme = Mapper.Map<List<SolicitudDenunciaModel>>(listadoDenuncia);
        }

        public void ObtenerTipoDenuncia(int idDenuncia)
        {
            Denuncia = new SolicitudDenunciaModel();
            var denunciaServicio = new SolicitudDenunciaServicio();
            var denunciaEntidad = denunciaServicio.ObtenerDenuncia(idDenuncia);

            Denuncia = Mapper.Map<SolicitudDenunciaModel>(denunciaEntidad);


            var Result = Denuncia.Georeferencia;
            try
            {
                JObject jArray = JObject.Parse(Result);
                Denuncia.Direccion = (string)jArray["results"][0]["formatted_address"];
            }
            catch (Exception e)
            {
                //Implementar nueva llamada al servicio para que obtenga la dirección
                Denuncia.Direccion = "Sin Dirección";
            }

        }

        public void Buscar(FormCollection form)
        {
            string IdTipoDenuncia = Convert.ToString(form["IdTipoDenuncia"]);
            string IdEstado = ((int)Entidad.Enums.EnumEstadoDenuncia.Pendiente).ToString();
            string FechaSolicitudDesde = Convert.ToString(form["FechaSolicitudDesde"]);
            string FechaSolicitudHasta = Convert.ToString(form["FechaSolicitudHasta"]);
            string IdCategoria = Convert.ToString(form["IdCategoria"]);
            string IdSubCategoria = Convert.ToString(form["IdSubCategoria"]);
            string IdRegion = Convert.ToString(form["IdRegion"]);
            string IdComuna = Convert.ToString(form["IdComuna"]);

            SolicitudDenunciaServicio servicio = new SolicitudDenunciaServicio();
            var lista = servicio.Buscar(IdEstado, IdTipoDenuncia,
               FechaSolicitudDesde,
               FechaSolicitudHasta,
               IdCategoria,
               IdSubCategoria,
               IdRegion,
               IdComuna,
               Autorizacion.IdentityUser.UserName);
            ListaDenunciasInforme = Mapper.Map<List<SolicitudDenunciaModel>>(lista);
        }

        public string ConstruirDescripcion(string descripcion, string referencia)
        {
            return string.Format("{0}\n{1}", descripcion, referencia);
        }

        public void ModificarDenuncia(FormCollection denunciaModel)
        {
            var denunciaServicio = new SolicitudDenunciaServicio();
            var denunciaEntidad = denunciaServicio.ObtenerDenuncia(int.Parse(denunciaModel.Get("IdDenuncia")));
            if (denunciaEntidad != null)
            {
                denunciaEntidad.Descripcion = ConstruirDescripcion(denunciaModel.Get("Descripcion"), denunciaModel.Get("Referencia"));
                denunciaEntidad.Comentario = denunciaModel.Get("Comentario");
                denunciaEntidad.IdEstadoDenuncia = int.Parse(denunciaModel.Get("IdEstadoDenuncia"));
                denunciaEntidad.idSubCategoria = int.Parse(denunciaModel.Get("IdSubCategoriaNueva"));


                if (denunciaEntidad.IdEstadoDenuncia == (int)Entidad.Enums.EnumEstadoDenuncia.Positivo ||
                denunciaEntidad.IdEstadoDenuncia == (int)Entidad.Enums.EnumEstadoDenuncia.Negativo)
                {
                    denunciaEntidad.FechaAprobacion = DateTime.Now;
                    denunciaEntidad.UserAprobacion = Autorizacion.IdentityUser.UserName;
                    if (!string.IsNullOrEmpty(denunciaEntidad.CorreoContacto))
                    {
                        Funciones.Funciones.EnviarCorreo(denunciaEntidad);
                    }
                }
                if (denunciaEntidad.IdEstadoDenuncia == (int)Entidad.Enums.EnumEstadoDenuncia.NoAplica)
                {
                    denunciaEntidad.FechaAprobacion = DateTime.Now;
                    denunciaEntidad.UserAprobacion = Autorizacion.IdentityUser.UserName;
                }
                denunciaServicio.ModificarDenuncia(denunciaEntidad);

            }

        }
    }
}