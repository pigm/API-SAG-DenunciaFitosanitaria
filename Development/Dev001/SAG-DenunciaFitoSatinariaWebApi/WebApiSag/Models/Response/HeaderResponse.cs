using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSag.Models.Response
{
    public class HeaderResponse
    {
        public int code { get; set; }
        public string token { get; set; }
        public string description { get; set; }
    }
}