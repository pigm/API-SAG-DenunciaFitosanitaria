using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using Denuncia.Negocio;

namespace Denuncia.Presentacion.MVC.Web.Autorizacion
{
    public class CustomVisibilityProvider : SiteMapNodeVisibilityProviderBase
    {
        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {
            try
            {
                var mvcNode = node as MvcSiteMapProvider.SiteMapNode;
                if (mvcNode == null)
                    return true;

                if (mvcNode.Attributes.Count == 0)
                    return true;

                string visibility = mvcNode.Attributes["visibility"].ToString();
                if (string.IsNullOrEmpty(visibility))
                    return true;

                var webSiteMapServicio = new WebSiteMapServicio();
                var acceso = int.Parse(visibility);
                var roles = webSiteMapServicio.ObtenerRolesAcceso(acceso);
                foreach(var rol in roles)
                {
                    if (HttpContext.Current.User.IsInRole(rol))
                        return true;
                }
                return false;
            }
            catch { return true; }
        }


    }
}