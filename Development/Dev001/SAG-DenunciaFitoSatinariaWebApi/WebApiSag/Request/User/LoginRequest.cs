using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request
{
    public class LoginRequest 
    {
        [Required]
        public string user { get; set; }

        [Required]
        public string password { get; set; }

    }
}