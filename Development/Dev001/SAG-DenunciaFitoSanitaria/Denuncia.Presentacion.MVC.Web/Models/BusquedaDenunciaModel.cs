using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class BusquedaDenunciaModel
    {
        //public BusquedaDenunciaModel()
        //{
        //    ObtenerTipoDenuncia();
        //    ObtenerEstadosDenucia();
        //}

        [Display(Name = "Tipo de Denuncia")]
        public int? IdTipoDenuncia { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }

        [Display(Name = "Estado de Denuncia")]
        public int? IdEstado { get; set; }

        public List<SelectListItem> ListaTipoDenuncia { get; set; }

        public List<SelectListItem> ListaEstadoDenuncia { get; set; }
    }
}