using Denuncia.Negocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class SubCategoriaModel : IValidatableObject
    {
        public SubCategoriaModel()
        {
            EsNuevo = true;
            ObtenerTipoCategoria();
            CategoriaModel = new CategoriaModel();
            SubCategoria_Imagenes = new SubCategoriaImagenesModel();
        }

        public int IdSubCategoria { get; set; }

        [DisplayName("Categoría")]
        [Required(ErrorMessage = "Debe ingresar Categoria.")]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Debe ingresar Nombre.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar Descripción.")]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Imágen")]
        public string ImagenUrl { get; set; }
        [DisplayName("Anónimo")]
        public bool Anonimo { get; set; }
        public bool Estado { get; set; }

        public string NombreEstado
        {
            get
            {
                if (Estado)
                    return "Activo";
                return "Inactivo";
            }
        }

        public bool EsNuevo { get; set; }
        public SubCategoriaImagenesModel SubCategoria_Imagenes { get; set; }
        public HttpPostedFileBase FotoImagen { get; set; }
        public string NombreCategoria { get; set; }
        public List<SelectListItem> ListaCategorias { get; set; }

        public CategoriaModel CategoriaModel { get; set; }
        public ICollection<SolicitudDenunciaModel> DenunciaModel { get; set; }

        public void ObtenerTipoCategoria()
        {
            ListaCategorias = new List<SelectListItem>();
            var tipoCategoriaServicio = new CategoriaServicio();
            var listaCategoria = tipoCategoriaServicio.ListaCategorias();
            //ListaCategorias.Add(new SelectListItem { Value = "0", Text = "Seleccione Categoría" });
            foreach (var categoria in listaCategoria)
            {
                ListaCategorias.Add(new SelectListItem
                {
                    Value = categoria.IdCategoria.ToString(),
                    Text = categoria.Nombre
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validates = new List<ValidationResult>();
            
            if (SubCategoria_Imagenes.FotoImagen2 != null && SubCategoria_Imagenes.FotoImagen1 == null)
                validates.Add(new ValidationResult("Debe inserta Imágen 1.", new[] { "SubCategoria_Imagenes.Imagen1" }));

            if (SubCategoria_Imagenes.FotoImagen3 != null && SubCategoria_Imagenes.FotoImagen2 == null)
                validates.Add(new ValidationResult("Debe inserta Imágen 2.", new[] { "SubCategoria_Imagenes.Imagen2" }));

            if (SubCategoria_Imagenes.FotoImagen4 != null && SubCategoria_Imagenes.FotoImagen3 == null)
                validates.Add(new ValidationResult("Debe inserta Imágen 3.", new[] { "SubCategoria_Imagenes.Imagen3" }));

            return validates;
        }
    }
}