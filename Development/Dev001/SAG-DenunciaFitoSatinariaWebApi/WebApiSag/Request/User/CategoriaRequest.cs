using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.User
{
    public class CategoriaRequest
    {
        [Required]
        public bool estado { get; set; }
    }
}