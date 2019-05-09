using AutoMapper;
using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class InformeGeneralModel
    {

        public InformeGeneralModel()
        {

            ListaTipoDenuncia = Funciones.Funciones.ObtenerTipos(Autorizacion.IdentityUser.UserName);
        }
        [DisplayName("Tipo Denuncia")]
        public int IdTipoDenuncia { get; set; }
        public int Categoria { get; set; }
        public int Subcategoria { get; set; }
        public string region { get; set; }
        public string Comuna { get; set; }
        public int Estado { get; set; }
        public string fechaHasta { get; set; }
        public string fechaDesde { get; set; }
        public List<SelectListItem> solicitudTipo { get; set; }       
        public List<SelectListItem> ListaTipoDenuncia { get; set; }
        


    }
}