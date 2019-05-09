using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.User
{
    public class DenunciaRequest
    {
        [Required]
        public int iddenuncia { get; set; }
        public string CorreoContacto{ get; set; }
        public string TelefonoContacto{ get; set; }
    }
   
}