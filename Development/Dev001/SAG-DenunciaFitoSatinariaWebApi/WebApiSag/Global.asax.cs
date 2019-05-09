﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApiSag
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //test
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //////Evito las referencias circulares al trabajar con Entity FrameWork         
            ////GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            ////GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //////Elimino que el sistema devuelva en XML, sólo trabajaremos con JSON
            ////GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
