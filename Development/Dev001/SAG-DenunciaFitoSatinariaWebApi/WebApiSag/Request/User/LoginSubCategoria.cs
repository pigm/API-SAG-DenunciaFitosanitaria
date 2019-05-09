using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.User
{
    public class LoginSubCategoria
    {
        [Required]
        public int idsubcategoria { get; set; }

        [Required]
        public bool estado { get; set; }
    }
}