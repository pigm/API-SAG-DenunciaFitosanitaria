using System.ComponentModel;
using System.Web;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class SubCategoriaImagenesModel //: IValidatableObject
    {      
        [DisplayName("Descripción")]
        public string Descripcion1 { get; set; }
        [DisplayName("Imágen")]
        public string Imagen1 { get; set; }
        public HttpPostedFileBase FotoImagen1 { get; set; }

        [DisplayName("Descripción")]        
        public string Descripcion2 { get; set; }
        [DisplayName("Imágen")]
        public string Imagen2 { get; set; }
        public HttpPostedFileBase FotoImagen2 { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion3 { get; set; }
        [DisplayName("Imágen")]
        public string Imagen3 { get; set; }
        public HttpPostedFileBase FotoImagen3 { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion4 { get; set; }
        [DisplayName("Imágen")]
        public string Imagen4 { get; set; }
        public HttpPostedFileBase FotoImagen4 { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (this.FotoImagen1 != null && string.IsNullOrEmpty(this.Descripcion1))
        //    {
        //        yield return new ValidationResult("Se debe ingresar descripción.", new[] { "Descripcion" });
        //    }
        //    else if (this.FotoImagen1 != null)
        //    {
        //        var exten = Path.GetExtension(this.FotoImagen1.FileName.ToString());

        //        if (!(exten.ToLower() == ".png" || exten.ToLower() == ".jpg" || exten.ToLower() == ".jpeg" || exten.ToLower() == ".gif"))
        //        {
        //            yield return new ValidationResult("Se debe seleccionar un archivo imagen.", new[] { "FotoImagen" });
        //        }
        //    }


        //    if (this.FotoImagen2 != null && string.IsNullOrEmpty(this.Descripcion2))
        //    {
        //        yield return new ValidationResult("Se debe ingresar descripción.", new[] { "Descripcion2" });
        //    }
        //    else if (this.FotoImagen2 != null)
        //    {
        //        var exten = Path.GetExtension(this.FotoImagen2.FileName.ToString());

        //        if (!(exten.ToLower() == ".png" || exten.ToLower() == ".jpg" || exten.ToLower() == ".jpeg" || exten.ToLower() == ".gif"))
        //        {
        //            yield return new ValidationResult("Se debe seleccionar un archivo imagen.", new[] { "FotoImagen2" });
        //        }
        //    }

        //    if (this.FotoImagen3 != null && string.IsNullOrEmpty(this.Descripcion3))
        //    {
        //        yield return new ValidationResult("Se debe ingresar descripción.", new[] { "Descripcion3" });
        //    }
        //    else if (this.FotoImagen3 != null)
        //    {
        //        var exten = Path.GetExtension(this.FotoImagen3.FileName.ToString());

        //        if (!(exten.ToLower() == ".png" || exten.ToLower() == ".jpg" || exten.ToLower() == ".jpeg" || exten.ToLower() == ".gif"))
        //        {
        //            yield return new ValidationResult("Se debe seleccionar un archivo imagen.", new[] { "FotoImagen3" });
        //        }
        //    }

        //    if (this.FotoImagen4 != null && string.IsNullOrEmpty(this.Descripcion4))
        //    {
        //        yield return new ValidationResult("Se debe ingresar descripción.", new[] { "Descripcion4" });
        //    }
        //    else if (this.FotoImagen4 != null)
        //    {
        //        var exten = Path.GetExtension(this.FotoImagen4.FileName.ToString());

        //        if (!(exten.ToLower() == ".png" || exten.ToLower() == ".jpg" || exten.ToLower() == ".jpeg" || exten.ToLower() == ".gif"))
        //        {
        //            yield return new ValidationResult("Se debe seleccionar un archivo imagen.", new[] { "FotoImagen4" });
        //        }
        //    }
        //}
    }
}