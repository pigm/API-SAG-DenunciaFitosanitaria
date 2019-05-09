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
    public class UsuarioModel
    {
        public Guid IdUsuario { get; set; }
               
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Debe ingresar e-mail.")]
        [EmailAddress(ErrorMessage = "Debe ingresar E-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe seleccionar rol.")]
        public string Rol { get; set; }
        public bool EsNuevo { get; set; }

        public List<SelectListItem> ListaRol { get; set; }
        
        public bool ModificaDenuncia { get; set; }
       

        public UsuarioModel()
        {
            EsNuevo = true;
            ModificaDenuncia = true;
            ObtenerRoles();
        }
        

        public void ObtenerRoles()
        {
            ListaRol = new List<SelectListItem>();
            var listaRoles = Roles.GetAllRoles();
            ListaRol.Add(new SelectListItem { Value = "", Text = "Seleccione Rol" });

            foreach (string rol in listaRoles)
            {
                ListaRol.Add(new SelectListItem
                {
                    Value = rol.ToString(),
                    Text = rol
                });
            }
        }
    }
}