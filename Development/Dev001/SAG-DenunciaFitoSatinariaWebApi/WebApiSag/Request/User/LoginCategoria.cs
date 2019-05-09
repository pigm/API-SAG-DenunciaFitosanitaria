using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.User
{
    public class LoginCategoria
    {
        [Required]
        public int idCategoria { get; set; }

        [Required]
        public bool estado { get; set; }
    }
}