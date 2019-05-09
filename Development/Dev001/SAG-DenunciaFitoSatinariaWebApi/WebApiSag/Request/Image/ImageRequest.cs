using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.Image
{
    public class ImageRequest
    {
            [Required]
            public int formato { get; set; }
            [Required]
            public string url { get; set; }

        } 
}