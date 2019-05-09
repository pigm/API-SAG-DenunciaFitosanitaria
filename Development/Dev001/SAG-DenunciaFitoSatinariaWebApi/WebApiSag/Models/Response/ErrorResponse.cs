using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSag.Models.Response
{
    public class ErrorResponse
    {
        public int errorCode { get; set; }
        public string errorDescription { get; set; }
    }
}