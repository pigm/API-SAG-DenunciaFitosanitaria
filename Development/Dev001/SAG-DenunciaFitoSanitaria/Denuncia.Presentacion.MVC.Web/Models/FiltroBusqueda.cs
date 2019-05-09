using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class FiltroBusqueda
    {
        [DisplayName("N° Solicitud")]
        public int IdDenuncia { get; set; }
        public DateTime? fechaDesde { get; set; }
        public DateTime? fechaHasta { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string EstadoDenuncia { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        [DisplayName ("Descripción")]
        public string Descripcion { get; set; }

        public string TipoDenuncia { get; set; }
    }
}