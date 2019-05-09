using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.User
{
    public class TipoDenunciaReques
    {
        [Required]
        public bool estado { get; set; }
    }
}