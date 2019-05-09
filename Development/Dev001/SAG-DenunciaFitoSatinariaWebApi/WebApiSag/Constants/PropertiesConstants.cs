using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebApiSag.Constants
{
    public class PropertiesConstants
    {
        public static string DATA_IN = "REQUEST : ";
        public static string DATA_OUT = "RESPONSE : ";
        public static string ERROR_DATA = ConfigurationManager.AppSettings["ErrorData"];
    }
}