using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.User
{ 
    public class LoginDenuncia
    {
        [Required]
        public int IdDenuncia { get; set; }

        [Required]
        public int idestadodenuncia { get; set; }
    }
}