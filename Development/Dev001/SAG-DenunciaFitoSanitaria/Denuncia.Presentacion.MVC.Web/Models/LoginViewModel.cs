using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Debe ingresar el nombre de usuario.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Debe ingresar la contraseña.")]
        public string Password { get; set; }
    }
}