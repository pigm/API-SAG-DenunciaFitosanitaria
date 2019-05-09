using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class RolModel : IValidatableObject
    {
        [Required(ErrorMessage = "Debe ingresar Nombre.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe seleccionar al menos un acceso.")]
        public List<SubCategoriaModel> ListaSubCategoria { get; set; }

        [Required(ErrorMessage = "Se debe seleccionar sub-sategorías.")]
        public int[] IdSubCategoria { get; set; }

        public string Acceso { get; set; }
        public List<JsTreeModel> JsonMenu { get; set; }
        public bool EsNuevo { get; set; }
        public MultiSelectList SubCategoriaMultiSelect
        {
            get { return new MultiSelectList(this.ListaSubCategoria, "IdSubCategoria", "Nombre", "NombreCategoria", IdSubCategoria); }
        }

        public RolModel()
        {
            ObtenerMenu();
            ObtenerSubCategorias();
        }

        
        public void ObtenerMenu()
        {
            JsonMenu = new List<JsTreeModel>();
            var sitemapServicio = new WebSiteMapServicio();
            var listaMenu = sitemapServicio.ListaMenu();

            foreach (var menu in listaMenu)
            {
                if (menu.ParentID == null)
                    JsonMenu.Add(new JsTreeModel(menu.ID, "#", menu.Title, menu.Image));
                else
                    JsonMenu.Add(new JsTreeModel(menu.ID, menu.ParentID.ToString(), menu.Title, null));
            }
        }

        public void ObtenerSubCategorias()
        {
            ListaSubCategoria = new List<SubCategoriaModel>();
            var categoriaServicio = new SubCategoriaServicio();
            var listaSubCategoria = categoriaServicio.ListaSubCategoria();
            foreach (var subCategoria in listaSubCategoria)
            {
                ListaSubCategoria.Add(new SubCategoriaModel
                {
                    IdSubCategoria = subCategoria.IdSubCategoria,
                    Nombre = subCategoria.Nombre,
                    NombreCategoria = subCategoria.Categoria.Nombre
                });
            }
        }


        public void SelectJsTree()
        {
            var array = Acceso.Split(',');
            foreach (var menu in JsonMenu)
            {
                if (array.Contains(menu.id.ToString()))
                    menu.state.selected = true;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EsNuevo)
            {
                if (Roles.RoleExists(Nombre))
                    yield return new ValidationResult("Rol ya existe.", new[] { "Nombre" });
            }
        }
    }
}