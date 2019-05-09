using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class TipoDenunciaModel //: IValidatableObject
    {
        public TipoDenunciaModel()
        {
            EsNuevo = true;
        }

        public int IdTipoDenuncia { get; set; }
        [Required(ErrorMessage = "Debe ingresar Nombre.")]
        public string Nombre { get; set; }
        public bool Incognito { get; set; }
        public bool Estado { get; set; }
        public bool EsNuevo { get; set; }

    }
}