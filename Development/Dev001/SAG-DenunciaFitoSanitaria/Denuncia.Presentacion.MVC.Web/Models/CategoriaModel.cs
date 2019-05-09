using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class CategoriaModel //: IValidatableObject
    {
        public CategoriaModel()
        {
            EsNuevo = true;
            CategoriaTipoDenunciaModel = new List<CategoriaTipoDenunciaModel>();
            SubCategoriaModel = new List<SubCategoriaModel>();
            ListaTipoDenuncia = Funciones.Funciones.ObtenerTipos();
        }

        public int IdCategoria { get; set; }

        [DisplayName("Tipo Denuncia")]
        public int IdTipoDenuncia { get; set; }

        public TipoDenunciaModel Denuncia { get; set; }
        [Required(ErrorMessage = "Debe ingresar Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Imagen")]
        public string ImagenUrl { get; set; }
        public string NombreImagen { get; set; }
        public bool Estado { get; set; }
        public bool EsNuevo { get; set; }
        public HttpPostedFileBase FotoImagen { get; set; }
        public string TipoDenuncia { get; set; }
        public List<SelectListItem> ListaTipoDenuncia { get; set; }

        public List<CategoriaTipoDenunciaModel> CategoriaTipoDenunciaModel { get; set; }
        public List<SubCategoriaModel> SubCategoriaModel { get; set; }
    }
}