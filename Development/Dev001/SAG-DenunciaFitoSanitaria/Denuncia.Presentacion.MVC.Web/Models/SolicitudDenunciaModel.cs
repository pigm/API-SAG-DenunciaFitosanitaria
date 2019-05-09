using AutoMapper;
using Denuncia.Entidad;
using Denuncia.Negocio;
using Denuncia.Presentacion.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class SolicitudDenunciaModel
    {
        public SolicitudDenunciaModel()
        {

            listTipo = Funciones.Funciones.ObtenerTipos(Autorizacion.IdentityUser.UserName);
            ListaCategoria = Funciones.Funciones.ObtenerCategoria(Autorizacion.IdentityUser.UserName);
            ListaRegion = Funciones.Funciones.ObtenerRegion(Autorizacion.IdentityUser.UserName);
            ListaSubCategoria = Funciones.Funciones.ObtenerSubcategoria();
            ListaComuna = Funciones.Funciones.ObtenerComuna(Autorizacion.IdentityUser.UserName);
            ListaEstado = Funciones.Funciones.ObtenerEstado();
            ListaEstadoGeneral = Funciones.Funciones.ObtenerEstadoInformeGeneral();
            ListaEstadoEspacial = Funciones.Funciones.ObtenerEstadoInformeEspacial();
        }

        public int IdTipoDenuncia { get; set; }
        public int IdCategoria { get; set; }
        public int IdRegion { get; set; }
        public int IdSubCategoria { get; set; }
        public int IdSubCategoriaNueva { get; set; }
        public int IdComuna { get; set; }
        public int IdEstado { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string EstadoDenuncia { get; set; }
        public int IdDenuncia { get; set; }
        public int IdEstadoDenuncia { get; set; }
        public byte[] Foto { get; set; }
        public string TipoDenuncia { get; set; }
        public string NombreTipoDenuncia { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public DateTime? Datefrom { get; set; }
        public string Georeferencia { get; set; }
        public string Direccion { get; set; }
        public DateTime? DateTo { get; set; }

        public SubCategoria subcategoria { get; set; }

        public TipoDenunciaModel TipoDenunciaModel { get; set; }

        [Required(ErrorMessage = "Inserte Comentario")]
        public string Comentario { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string DescripcionCorta
        {
            get
            {
                if (string.IsNullOrEmpty(Descripcion))
                    return string.Empty;
                if (Descripcion.Length > 30)
                    return string.Format("{0}...", Descripcion.Substring(0, 30));
                return Descripcion;
            }
        }

        public string DescripcionCortada
        {
            get
            {
                if (string.IsNullOrEmpty(Descripcion))
                    return string.Empty;
                else
                {
                    string s = Descripcion;
                    string[] words = s.Split('\n');
                    return words[0].ToString();
                }
            }
        }

        public string Referencia
        {
            get
            {
                if (string.IsNullOrEmpty(Descripcion))
                    return string.Empty;
                else
                {
                    string s = Descripcion;
                    string[] words = s.Split('\n');
                    return words[1].Replace("Referencia:", string.Empty).ToString();
                }
            }
        }

        public bool DenunciaRapida { get; set; }

        [Display(Name = "Correo")]
        public string CorreoContacto { get; set; }

        [Display(Name = "Teléfono")]
        public string TelefonoContacto { get; set; }

        [Display(Name = "Fecha de Creación")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime FechaEnvio { get; set; }

        [Display(Name = "Mensaje de Voz")]
        public string MensajeVoz { get; set; }

        [Display(Name = "Tipo de Denuncia")]
        public List<SelectListItem> listTipo { get; set; }

        public SubCategoriaModel SubCategoriaModel { get; set; }

        public List<CategoriaTipoDenunciaModel> CatTipoDenunciaModel { get; set; }

        public List<SelectListItem> ListaCategoria { get; set; }

        public List<SelectListItem> ListaRegion { get; set; }

        public List<SelectListItem> ListaSubCategoria { get; set; }
        public List<SelectListItem> ListaSubCategoriaDenuncia { get; set; }

        public List<SelectListItem> ListaComuna { get; set; }

        public List<SelectListItem> ListaEstado { get; set; }
        public List<SelectListItem> ListaEstadoGeneral { get; set; }
        public List<SelectListItem> ListaEstadoEspacial { get; set; }
        public List<TipoDenunciaModel> ListaTipoDenuncia { get; set; }
        public List<SolicitudDenunciaModel> ListaDenunciasInforme { get; set; }
        [Display(Name = "Imagen")]
        public string ImagenUrl { get; set; }

        public string latitud { get; set; }

        public string longitud { get; set; }
        [Display(Name = "Usuario Atención")]
        public string UserAprobacion { get; set; }
        [Display(Name = "Fecha Atención")]
        public DateTime? FechaAprobacion { get; set; }


        public void LlenaListas()
        {
            SolicitudDenunciaServicio servicio = new SolicitudDenunciaServicio();
            var lista = servicio.ListaDenunciaPorUsuario(Autorizacion.IdentityUser.UserName);
            ListaDenunciasInforme = Mapper.Map<List<SolicitudDenunciaModel>>(lista);
        }

        public void Buscar(FormCollection form)
        {
            string IdTipoDenuncia = Convert.ToString(form["IdTipoDenuncia"]);
            string IdEstado = Convert.ToString(form["IdEstado"]);
            string FechaSolicitudDesde = Convert.ToString(form["FechaSolicitudDesde"]);
            string FechaSolicitudHasta = Convert.ToString(form["FechaSolicitudHasta"]);
            string IdCategoria = Convert.ToString(form["IdCategoria"]);
            string IdSubCategoria = Convert.ToString(form["IdSubCategoria"]);
            string IdRegion = Convert.ToString(form["IdRegion"]);
            string IdComuna = Convert.ToString(form["IdComuna"]);

            SolicitudDenunciaServicio servicio = new SolicitudDenunciaServicio();
            var lista = servicio.Buscar(IdEstado,
               IdTipoDenuncia,
               FechaSolicitudDesde,
               FechaSolicitudHasta,
               IdCategoria,
               IdSubCategoria,
               IdRegion,
               IdComuna,
               Autorizacion.IdentityUser.UserName);
            ListaDenunciasInforme = Mapper.Map<List<SolicitudDenunciaModel>>(lista);
        }


        public void BuscarEspacial(FormCollection form)
        {
            string IdTipoDenuncia = Convert.ToString(form["IdTipoDenuncia"]);
            string IdEstado = Convert.ToString(form["IdEstado"]);
            string FechaSolicitudDesde = Convert.ToString(form["FechaSolicitudDesde"]);
            string FechaSolicitudHasta = Convert.ToString(form["FechaSolicitudHasta"]);
            string IdCategoria = Convert.ToString(form["IdCategoria"]);
            string IdSubCategoria = Convert.ToString(form["IdSubCategoria"]);
            string IdRegion = Convert.ToString(form["IdRegion"]);
            string IdComuna = Convert.ToString(form["IdComuna"]);

            SolicitudDenunciaServicio servicio = new SolicitudDenunciaServicio();
            var lista = servicio.Buscar(IdEstado,
               IdTipoDenuncia,
               FechaSolicitudDesde,
               FechaSolicitudHasta,
               IdCategoria,
               IdSubCategoria,
               IdRegion,
               IdComuna,
               Autorizacion.IdentityUser.UserName).Where(den => den.IdEstadoDenuncia == (int)Entidad.Enums.EnumEstadoDenuncia.Positivo || den.IdEstadoDenuncia == (int)Entidad.Enums.EnumEstadoDenuncia.Negativo);
            ListaDenunciasInforme = Mapper.Map<List<SolicitudDenunciaModel>>(lista.Where(x => x.latitud.Trim() != string.Empty && x.longitud.Trim() != string.Empty));
        }


    }
}